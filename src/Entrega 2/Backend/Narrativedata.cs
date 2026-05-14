public static class NarrativeData
{
    // ── PRÓLOGO ─────────────────────────────────────────────────────────
    public static string PrologueOpening =
        "Os últimos humanos vivem embaixo da terra.\n\nLá em cima, nada cresce mais.\n\nMas aqui embaixo...\ntinha algo diferente.";

    public static string PrologueFoundSeedling =
        "Ela ainda tá viva.\n\nUma plantinha, aqui no meio do nada.\n\nComo ela sobreviveu até agora?";

    public static string ProloguePlanted =
        "Aqui ela vai crescer.\n\nDebaixo dessa luz fraquinha...\n\nÉ o melhor que eu tenho.";

    public static string PrologueReadyToSleep =
        "Tá bom. Ela tá segura agora.\n\nPreciso dormir.";

    public static string PrologueBeforeSleep =
        "Amanhã eu cuido melhor dela.";

    // ── ACORDAR — DIAS FIXOS (1, 2, 3) ─────────────────────────────────
    public static string[] WakeFixed = new string[]
    {
        // Dia 1
        "A terra tá seca.\n\nPreciso adubar antes de regar.\n\nMeu bisavô falava isso.",

        // Dia 2
        "O bisavô dizia que árvores tocavam o céu…\n\nTalvez você também consiga.",

        // Dia 3
        "Tenho duas canecas…\n\nMas acho que você precisa mais do que eu."
    };

    // ── ACORDAR — DIAS DINÂMICOS (4, 5, 6) ──────────────────────────────
    // [linha] = dia-4  |  [coluna] 0=Silêncio  1=Estagnação  2=Renascimento
    public static string[,] WakeDynamic = new string[,]
    {
        // Dia 4
        {
            "Não usei nada…\n\nSua terra ficou seca.\n\nVocê não respondeu à luz.",
            "Você continua igual, sem mudar.",
            "Sua raiz parece respirar melhor."
        },
        // Dia 5
        {
            "Bebi primeiro…\n\nVocê ficou sem nada.",
            "A lâmpada brilha, mas nada muda…\n\nNem em você, nem em mim.",
            "A lâmpada é fraca, mas eu acredito…\n\nCada gota que dou te faz crescer."
        },
        // Dia 6
        {
            "Você se curvou e não voltou…",
            "Não sei o que escolher…\n\nEntão não escolho.\n\nTudo permanece suspenso.",
            "Estou cansado, mas vou dividir tudo com você…\n\nQuero ver você florescer."
        }
    };

    // ── FINAIS ───────────────────────────────────────────────────────────
    public static string EndingGood =
        "Você cresceu devagar, folha por folha.\n\n" +
        "Nos túneis sem luz, guardou cada gota que eu dei.\n\n" +
        "Quando acordei, fraca e cansada, vi você florescer.\n\n" +
        "Eu não estava sozinho.";

    public static string EndingNeutral =
        "A vida sempre foi feita de escolhas difíceis.\n\n" +
        "Eu sabia disso desde o início.\n\n" +
        "Mas escolhi não escolher.\n\n" +
        "Você continuou amarela. Eu continuei com sede.\n\n" +
        "E nada mudou.";

    public static string EndingBad =
        "A última esperança da Terra morreu no escuro.\n\n" +
        "Nenhuma outra raiz foi plantada.\n\n" +
        "Eu sobrevivi.\n\n" +
        "E carreguei comigo o peso de um silêncio sem futuro.";
}