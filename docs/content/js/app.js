import 'https://cdnjs.cloudflare.com/ajax/libs/reveal.js/4.6.1/reveal.min.js';
import 'https://cdnjs.cloudflare.com/ajax/libs/reveal.js/4.6.1/plugin/markdown/markdown.min.js';
import 'https://cdnjs.cloudflare.com/ajax/libs/reveal.js/4.6.1/plugin/highlight/highlight.min.js';
import 'https://cdnjs.cloudflare.com/ajax/libs/reveal.js/4.6.1/plugin/notes/notes.min.js';

Reveal.initialize({
    history: true,
     // Transition style
    transition: 'fade', // none/fade/slide/convex/concave/zoom
    // Transition speed
    transitionSpeed: 'slow', // default/fast/slow
    // Transition style for full page slide backgrounds
    backgroundTransition: 'fade', // none/fade/slide/convex/concave/zoom
    plugins: [ RevealMarkdown, RevealHighlight, RevealNotes  ],
    width: 1200
    
});