using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace EdgarJairVazquezVillarreal.Services
{
    public class ThemeService
    {
        private readonly IJSRuntime _jsRuntime;

        public bool IsDarkMode { get; private set; } = true;

        public event Action? OnThemeChanged;

        public ThemeService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        /// <summary>
        /// Lee el tema guardado en localStorage y lo aplica via data-bs-theme en el elemento html.
        /// El script anti-flash en index.html ya aplicó el atributo antes de que Blazor cargue,
        /// pero aquí sincronizamos el estado del servicio y confirmamos el atributo.
        /// </summary>
        public async Task InitializeAsync()
        {
            try
            {
                var savedTheme = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "theme");
                IsDarkMode = savedTheme != "light"; // oscuro por defecto si no hay nada guardado
                await ApplyThemeAsync();
            }
            catch
            {
                // Ignorar errores de prerendering o si localStorage no está disponible
            }
        }

        public async Task ToggleThemeAsync()
        {
            IsDarkMode = !IsDarkMode;
            await ApplyThemeAsync();
        }

        private async Task ApplyThemeAsync()
        {
            var themeName = IsDarkMode ? "dark" : "light";
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "theme", themeName);
                // Bootstrap 5.3: atributo nativo data-bs-theme en el elemento <html>
                await _jsRuntime.InvokeVoidAsync("document.documentElement.setAttribute", "data-bs-theme", themeName);
            }
            catch
            {
                // Ignorar errores de prerendering
            }
            OnThemeChanged?.Invoke();
        }
    }
}
