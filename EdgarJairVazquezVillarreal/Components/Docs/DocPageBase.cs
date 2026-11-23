using System;
using EdgarJairVazquezVillarreal.Services;
using Microsoft.AspNetCore.Components;

namespace EdgarJairVazquezVillarreal.Components.Docs
{
    /// <summary>
    /// Base de las páginas de documentación de proyectos (@inherits DocPageBase).
    /// Inyecta el idioma, vuelve a renderizar cuando cambia y ofrece T(es, en)
    /// para escribir los textos de la página en ambos idiomas.
    /// </summary>
    public abstract class DocPageBase : ComponentBase, IDisposable
    {
        [Inject] protected LanguageService LangApp { get; set; } = default!;

        /// <summary>Devuelve el texto en el idioma activo.</summary>
        protected string T(string es, string en) => LangApp.IsSpanish ? es : en;

        protected string T((string Es, string En) text) => T(text.Es, text.En);

        protected override void OnInitialized()
        {
            LangApp.OnLanguageChanged += StateHasChanged;
        }

        public void Dispose()
        {
            LangApp.OnLanguageChanged -= StateHasChanged;
        }
    }

    /// <summary>Imagen de la galería de una página de documentación.</summary>
    public record DocImage(string Src, string CaptionEs, string CaptionEn);
}
