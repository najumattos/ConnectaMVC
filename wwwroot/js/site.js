<script>
	document.addEventListener("DOMContentLoaded", function() {
        // 1. Obtém o caminho da URL atual (ex: /Procedimento ou /Procedimento/Index)
        const currentPath = window.location.pathname;

	// 2. Seleciona todos os links da sidebar que você quer estilizar
	const navLinks = document.querySelectorAll('.custom-sidebar .nav-link');

        // Remove a classe 'active' de todos os links antes de começar
        navLinks.forEach(link => {
		link.classList.remove('active');
	link.classList.remove('text-primary'); // Garante que a cor do texto padrão seja aplicada
        });

        // 3. Itera sobre os links e verifica se o caminho da URL corresponde
        navLinks.forEach(link => {
            // Obtém o 'href' do link (ex: /Agendamentos, /Barbeiros, /Procedimentos)
            const linkHref = link.getAttribute('href');

	// Verifica se o caminho atual da URL inclui o caminho do link.
	// O '.toLowerCase()' garante que a comparação não diferencia maiúsculas/minúsculas.
	// O '.includes()' é mais robusto para URLs como '/Procedimento/Index'
	if (currentPath.toLowerCase().includes(linkHref.toLowerCase()) && linkHref !== '#') {

		// Aplica a estilização de ativo
		link.classList.add('active');

                // Dica: Adicione uma classe de cor do Bootstrap (ex: text-dark) para garantir a cor do texto no estilo ativo
                // Se você estiver usando o CSS do nosso exemplo anterior, a classe 'active' já cuida da cor.
            }
        });
    });
</script>
