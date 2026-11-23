// Animaciones del sitio: aparición al hacer scroll, contadores y texto tecleado.
//
// Blazor crea y destruye el DOM al navegar entre páginas, así que un
// MutationObserver registra los elementos nuevos conforme aparecen.
// Ninguna página necesita JS interop: basta con usar las clases/atributos.
//
//   .scroll-reveal            → aparece al entrar en pantalla
//   .counter[data-target]     → cuenta de 0 hasta data-target
//   [data-typed="a|b|c"]      → teclea y borra las frases en ciclo
(function () {
    'use strict';

    var reduceMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    var canObserve = 'IntersectionObserver' in window && 'MutationObserver' in window;
    var animate = canObserve && !reduceMotion;

    // El CSS solo oculta .scroll-reveal cuando existe esta clase; si este
    // script no carga o el usuario pidió menos movimiento, todo queda visible.
    if (animate) document.documentElement.classList.add('js-anim');

    var seen = new WeakSet();


    // ── Aparición al hacer scroll ───────────────────────────────────────
    var STAGGER_MS = 80;
    var MAX_STAGGER_STEPS = 6;

    var revealObserver = animate && new IntersectionObserver(function (entries, observer) {
        // Los elementos que entran juntos se escalonan de arriba a abajo
        // y de izquierda a derecha.
        entries
            .filter(function (e) { return e.isIntersecting; })
            .sort(function (a, b) {
                return a.boundingClientRect.top - b.boundingClientRect.top
                    || a.boundingClientRect.left - b.boundingClientRect.left;
            })
            .forEach(function (entry, i) {
                var el = entry.target;
                el.style.setProperty('--reveal-delay', Math.min(i, MAX_STAGGER_STEPS) * STAGGER_MS + 'ms');
                // Atributo en vez de clase: Blazor reescribe "class" cuando
                // cambia, pero nunca toca atributos que no renderizó.
                el.setAttribute('data-revealed', '');
                observer.unobserve(el);
            });
    }, { rootMargin: '0px 0px -8% 0px', threshold: 0 });


    // ── Contadores ──────────────────────────────────────────────────────
    var COUNT_MS = 1400;

    function setText(el, value) {
        // Se modifica el nodo de texto existente (no se reemplaza) para no
        // romper la referencia que Blazor guarda de él.
        var node = el.firstChild;
        if (node && node.nodeType === Node.TEXT_NODE) node.nodeValue = value;
        else el.textContent = value;
    }

    function runCounter(el) {
        var target = Number(el.getAttribute('data-target')) || 0;
        var start = performance.now();

        function tick(now) {
            var t = Math.min((now - start) / COUNT_MS, 1);
            var eased = 1 - Math.pow(1 - t, 3); // easeOutCubic
            setText(el, Math.round(target * eased));
            if (t < 1) requestAnimationFrame(tick);
        }
        requestAnimationFrame(tick);
    }

    var counterObserver = animate && new IntersectionObserver(function (entries, observer) {
        entries.forEach(function (entry) {
            if (!entry.isIntersecting) return;
            runCounter(entry.target);
            observer.unobserve(entry.target);
        });
    }, { threshold: 0.5 });


    // ── Texto tecleado ──────────────────────────────────────────────────
    var TYPE_MS = 55;
    var ERASE_MS = 28;
    var HOLD_MS = 1900;
    var GAP_MS = 350;

    var typingRun = new WeakMap(); // elemento → nº de ejecución vigente

    function phrasesOf(el) {
        return (el.getAttribute('data-typed') || '').split('|').filter(Boolean);
    }

    function startTyping(el) {
        var run = (typingRun.get(el) || 0) + 1;
        typingRun.set(el, run);

        if (!animate) {
            el.textContent = phrasesOf(el)[0] || '';
            return;
        }

        var index = 0;
        var length = 0;
        var erasing = false;
        el.textContent = '';

        function step() {
            // Se detiene si la página cambió o si data-typed cambió (idioma)
            // y ya hay una ejecución más nueva.
            if (!el.isConnected || typingRun.get(el) !== run) return;

            var phrases = phrasesOf(el);
            if (!phrases.length) return;
            var phrase = phrases[index % phrases.length];

            if (!erasing) {
                length++;
                el.textContent = phrase.slice(0, length);
                if (length >= phrase.length) {
                    erasing = true;
                    setTimeout(step, HOLD_MS);
                } else {
                    setTimeout(step, TYPE_MS);
                }
            } else {
                length--;
                el.textContent = phrase.slice(0, length);
                if (length <= 0) {
                    erasing = false;
                    index++;
                    setTimeout(step, GAP_MS);
                } else {
                    setTimeout(step, ERASE_MS);
                }
            }
        }
        step();
    }


    // ── Registro de elementos ───────────────────────────────────────────
    var SELECTOR = '.scroll-reveal, .counter[data-target], [data-typed]';

    function register(el) {
        if (seen.has(el)) return;
        seen.add(el);

        if (el.matches('.scroll-reveal') && animate) {
            revealObserver.observe(el);
        }
        if (el.matches('.counter[data-target]')) {
            if (animate) {
                setText(el, 0);
                counterObserver.observe(el);
            } else {
                setText(el, el.getAttribute('data-target'));
            }
        }
        if (el.matches('[data-typed]')) {
            startTyping(el);
        }
    }

    function scan(root) {
        if (root.nodeType !== Node.ELEMENT_NODE) return;
        if (root.matches(SELECTOR)) register(root);
        root.querySelectorAll(SELECTOR).forEach(register);
    }

    if (canObserve) {
        new MutationObserver(function (mutations) {
            mutations.forEach(function (m) {
                if (m.type === 'childList') {
                    m.addedNodes.forEach(scan);
                } else if (seen.has(m.target)) {
                    // data-typed cambió (cambio de idioma): reinicia el tecleo
                    startTyping(m.target);
                }
            });
        }).observe(document.documentElement, {
            childList: true,
            subtree: true,
            attributes: true,
            attributeFilter: ['data-typed']
        });
    }

    if (document.body) scan(document.body);
})();
