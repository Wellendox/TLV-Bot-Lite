namespace TLVLibrary;

public static class Markup
{
    #region Complex Markdown

    /// <summary>
    /// Makes the link.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="url">The URL.</param>
    /// <returns></returns>
    public static string MakeLink(string text, string url) => $"[{text}]({url})";

    #endregion Complex Markdown

    #region Simple Markdown

    /// <summary>
    /// Converts to italics.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToItalics(string text) => $"*{text}*";

    /// <summary>
    /// Converts to bold.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToBold(string text) => $"**{text}**";

    /// <summary>
    /// Converts to underline.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToUnderline(string text) => $"__{text}__";

    /// <summary>
    /// Converts to strikethrough.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToStrikeThrough(string text) => $"~~{text}~~";

    /// <summary>
    /// Converts to codeblocksingleline.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToCodeBlockSingleline(string text) => $"`{text}`";

    /// <summary>
    /// Converts to codeblockmultiline.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="languageCode">The language code.</param>
    /// <returns></returns>
    public static string ToCodeBlockMultiline(string text, string languageCode = null) => $"```{languageCode ?? ""}\n{text}```";

    /// <summary>
    /// Converts to codeblockmultiline.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="programmingLanguages">The programming languages.</param>
    /// <returns></returns>
    public static string ToCodeBlockMultiline(string text, Languages programmingLanguages) => $"```{Enum.GetName(typeof(Languages), programmingLanguages)}\n{text}```";

    /// <summary>
    /// Converts to blockquotesingleline.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToBlockQuoteSingleline(string text) => $"> {text}";

    /// <summary>
    /// Converts to blockquotemultiline.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToBlockQuoteMultiline(string text) => $">>> {text}";

    /// <summary>
    /// Converts to spoiler.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToSpoiler(string text) => $"||{text}||";

    #endregion Simple Markdown

    #region Composite Markdown

    /// <summary>
    /// Converts to bolditalics.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToBoldItalics(string text) => ToItalics(ToBold(text));

    /// <summary>
    /// Converts to underlineitalics.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToUnderlineItalics(string text) => ToUnderline(ToItalics(text));

    /// <summary>
    /// Converts to underlinebold.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToUnderlineBold(string text) => ToUnderline(ToBold(text));

    /// <summary>
    /// Converts to underlinebolditalics.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string ToUnderlineBoldItalics(string text) => ToUnderline(ToBold(ToItalics(text)));

    #endregion Composite Markdown

    /// <summary>
    /// The programming languages that support syntax highlighting inside code blocks
    /// </summary>
    public enum Languages
    {
        Actionscript3,
        Apache,
        Applescript,
        Asp,
        Brainfuck,
        C,
        Cfm,
        Clojure,
        Cmake,
        Coffeescript,
        Coffee,
        Cpp,
        Cs,
        Csharp,
        Css,
        Csv,
        Bash,
        Diff,
        Elixir,
        Erb,
        Go,
        Haml,
        Http,
        Java,
        Javascript,
        Json,
        Jsx,
        Less,
        Lolcode,
        Make,
        Markdown,
        Matlab,
        Nginx,
        Objectivec,
        Pascal,
        Php,
        Perl,
        Python,
        Profile,
        Rust,
        Salt,
        Saltstate,
        Shell,
        Sh,
        Zsh,
        Scss,
        Sql,
        Svg,
        Swift,
        Rb,
        Jruby,
        Ruby,
        Smalltalk,
        Vim,
        Viml,
        Volt,
        Vhdl,
        Vue,
        Xml,
        Yaml
    }

    /// <summary>
    /// Color Codes
    /// </summary>
    public enum ColorCodes : uint
    {
        /// <summary>
        /// Gets the grey 50 color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/7F7F7F">7F7F7F</see>.</returns>
        Default = 0x7F7F7F,

        /// <summary>
        /// Gets the aqua color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/00FFFF">00FFFF</see>.</returns>
        Aqua = 0x00FFFF,

        /// <summary>
        /// Gets the aquamarine color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/7FFFD3">7FFFD3</see>.</returns>
        Aquamarine = 0x7FFFD3,

        /// <summary>
        /// Gets the beige color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/F4F4DB">F4F4DB</see>.</returns>
        Beige = 0xF4F4DB,

        /// <summary>
        /// Gets the black color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/0C0C0C">0C0C0C</see>.</returns>
        Black = 0x0C0C0C,

        /// <summary>
        /// Gets the absolute black color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/000000">000000</see>.</returns>
        BlackAbsolute = 0x000000,

        /// <summary>
        /// Gets the blue color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/0000FF">0000FF</see>.</returns>
        Blue = 0x0000FF,

        /// <summary>
        /// Gets the dark blue color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/00008C">00008C</see>.</returns>
        BlueDark = 0x00008C,

        /// <summary>
        /// Gets the light blue color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/ADD8E5">ADD8E5</see>.</returns>
        BlueLight = 0xADD8E5,

        /// <summary>
        /// Gets the bronze color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/CD7F32">CD7F32</see>.</returns>
        Bronze = 0xCD7F32,

        /// <summary>
        /// Gets the antique bronze color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/665D1E">665D1E</see>.</returns>
        BronzeAntique = 0x665D1E,

        /// <summary>
        /// Gets the bronze blast off color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/A57164">A57164</see>.</returns>
        BronzeBlastOff = 0xA57164,

        /// <summary>
        /// Gets the brown color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/A52828">A52828</see>.</returns>
        Brown = 0xA52828,

        /// <summary>
        /// Gets the dark brown color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/5B3F33">5B3F33</see>.</returns>
        BrownDark = 0x5B3F33,

        /// <summary>
        /// Gets the light brown color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/AF7F51">AF7F51</see>.</returns>
        BrownLight = 0xAF7F51,

        /// <summary>
        /// Gets the coral color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FF7F4F">FF7F4F</see>.</returns>
        Coral = 0xFF7F4F,

        /// <summary>
        /// Gets the crimson color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/DB143D">DB143D</see>.</returns>
        Crimson = 0xDB143D,

        /// <summary>
        /// Gets the cyan color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/00FFFF">00FFFF</see>.</returns>
        Cyan = 0x00FFFF,

        /// <summary>
        /// Gets the dark cyan color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/008C8C">008C8C</see>.</returns>
        CyanDark = 0x008C8C,

        /// <summary>
        /// Gets the light cyan color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/E0FFFF">E0FFFF</see>.</returns>
        CyanLight = 0xE0FFFF,

        /// <summary>
        /// Gets the deep sky blue color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/00BFFF">00BFFF</see>.</returns>
        DeepSkyBlue = 0x00BFFF,

        /// <summary>
        /// Gets the dodger blue color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/1E90FF">1E90FF</see>.</returns>
        DodgerBlue = 0x1E90FF,

        /// <summary>
        /// Gets the firebrick color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/B22222">B22222</see>.</returns>
        Firebrick = 0xB22222,

        /// <summary>
        /// Gets the fuchsia color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FF00FF">FF00FF</see>.</returns>
        Fuchsia = 0xFF00FF,

        /// <summary>
        /// Gets the gold color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFD600">FFD600</see>.</returns>
        Gold = 0xFFD600,

        /// <summary>
        /// Gets the dark gold color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/EDBC1C">EDBC1C</see>.</returns>
        GoldDark = 0xEDBC1C,

        /// <summary>
        /// Gets the light gold color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/F2E5AA">F2E5AA</see>.</returns>
        GoldLight = 0xF2E5AA,

        /// <summary>
        /// Gets the green color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/007F00">007F00</see>.</returns>
        Green = 0x007F00,

        /// <summary>
        /// Gets the dark green color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/006300">006300</see>.</returns>
        GreenDark = 0x006300,

        /// <summary>
        /// Gets the light green color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/8EED8E">8EED8E</see>.</returns>
        GreenLight = 0x8EED8E,

        /// <summary>
        /// Gets the grey color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/7F7F7F">7F7F7F</see>.</returns>
        Grey = 0x7F7F7F,

        /// <summary>
        /// Gets the dark grey color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/3F3F3F">3F3F3F</see>.</returns>
        GreyDark = 0x3F3F3F,

        /// <summary>
        /// Gets the light grey color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/D3D3D3">D3D3D3</see>.</returns>
        GreyLight = 0xD3D3D3,

        /// <summary>
        /// Gets the indigo color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/4B0082">4B0082</see>.</returns>
        Indigo = 0x4B0082,

        /// <summary>
        /// Gets the ivory color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFFFEF">FFFFEF</see>.</returns>
        Ivory = 0xFFFFEF,

        /// <summary>
        /// Gets the dark ivory color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/F2E58E">F2E58E</see>.</returns>
        IvoryDark = 0xF2E58E,

        /// <summary>
        /// Gets the light ivory color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFF7C9">FFF7C9</see>.</returns>
        IvoryLight = 0xFFF7C9,

        /// <summary>
        /// Gets the light sky blue color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/87CEFA">87CEFA</see>.</returns>
        LightSkyBlue = 0x87CEFA,

        /// <summary>
        /// Gets the lime color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/00FF00">00FF00</see>.</returns>
        Lime = 0x00FF00,

        /// <summary>
        /// Gets the magenta color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FF00FF">FF00FF</see>.</returns>
        Magenta = 0xFF00FF,

        /// <summary>
        /// Gets the dark magenta color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/8C008C">8C008C</see>.</returns>
        MagentaDark = 0x8C008C,

        /// <summary>
        /// Gets the light magenta color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FF77FF">FF77FF</see>.</returns>
        MagentaLight = 0xFF77FF,

        /// <summary>
        /// Gets the maroon color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/B03060">B03060</see>.</returns>
        Maroon = 0xB03060,

        /// <summary>
        /// Gets the mustard color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFDB59">FFDB59</see>.</returns>
        Mustard = 0xFFDB59,

        /// <summary>
        /// Gets the dark mustard color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/7C7C3F">7C7C3F</see>.</returns>
        MustardDark = 0x7C7C3F,

        /// <summary>
        /// Gets the light mustard color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/EDDD60">EDDD60</see>.</returns>
        MustardLight = 0xEDDD60,

        /// <summary>
        /// Gets the orange color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFA500">FFA500</see>.</returns>
        Orange = 0xFFA500,

        /// <summary>
        /// Gets the dark orange color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FF8C00">FF8C00</see>.</returns>
        OrangeDark = 0xFF8C00,

        /// <summary>
        /// Gets the light orange color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/D8A366">D8A366</see>.</returns>
        OrangeLight = 0xD8A366,

        /// <summary>
        /// Gets the pink color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFBFCC">FFBFCC</see>.</returns>
        Pink = 0xFFBFCC,

        /// <summary>
        /// Gets the dark pink color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/E8547F">E8547F</see>.</returns>
        PinkDark = 0xE8547F,

        /// <summary>
        /// Gets the light pink color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFB6C1">FFB6C1</see>.</returns>
        PinkLight = 0xFFB6C1,

        /// <summary>
        /// Gets the purple color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/A021EF">A021EF</see>.</returns>
        Purple = 0xA021EF,

        /// <summary>
        /// Gets the dark purple color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/663399">663399</see>.</returns>
        PurpleDark = 0x663399,

        /// <summary>
        /// Gets the light purple color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/9370DB">9370DB</see>.</returns>
        PurpleLight = 0x9370DB,

        /// <summary>
        /// Gets the red color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FF0000">FF0000</see>.</returns>
        Red = 0xFF0000,

        /// <summary>
        /// Gets the dark red color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/8C0000">8C0000</see>.</returns>
        RedDark = 0x8C0000,

        /// <summary>
        /// Gets the light red color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FF3333">FF3333</see>.</returns>
        RedLight = 0xFF3333,

        /// <summary>
        /// Gets the silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/BFBFBF">BFBFBF</see>.</returns>
        Silver = 0xBFBFBF,

        /// <summary>
        /// Gets the chalice silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/ACACAC">ACACAC</see>.</returns>
        SilverChalice = 0xACACAC,

        /// <summary>
        /// Gets the crayola silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/C9C0BB">C9C0BB</see>.</returns>
        SilverCrayola = 0xC9C0BB,

        /// <summary>
        /// Gets the dark silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/AFAFAF">AFAFAF</see>.</returns>
        SilverDark = 0xAFAFAF,

        /// <summary>
        /// Gets the light silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/E0E0E0">E0E0E0</see>.</returns>
        SilverLight = 0xE0E0E0,

        /// <summary>
        /// Gets the old silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/848482">848482</see>.</returns>
        SilverOld = 0x848482,

        /// <summary>
        /// Gets the pink silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/C4AEAD">C4AEAD</see>.</returns>
        SilverPink = 0xC4AEAD,

        /// <summary>
        /// Gets the roman silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/838996">838996</see>.</returns>
        SilverRoman = 0x838996,

        /// <summary>
        /// Gets the sand silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/BFC1C2">BFC1C2</see>.</returns>
        SilverSand = 0xBFC1C2,

        /// <summary>
        /// Gets the sonic silver color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/757575">757575</see>.</returns>
        SilverSonic = 0x757575,

        /// <summary>
        /// Gets the teal color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/007F7F">007F7F</see>.</returns>
        Teal = 0x007F7F,

        /// <summary>
        /// Gets the turquoise color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/30D6C6">30D6C6</see>.</returns>
        Turquoise = 0x30D6C6,

        /// <summary>
        /// Gets the dark turquoise color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/00CED1">00CED1</see>.</returns>
        TurquoiseDark = 0x00CED1,

        /// <summary>
        /// Gets the light turquoise color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/AFE2DD">AFE2DD</see>.</returns>
        TurquoiseLight = 0xAFE2DD,

        /// <summary>
        /// Gets the violet color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/ED82ED">ED82ED</see>.</returns>
        Violet = 0xED82ED,

        /// <summary>
        /// Gets the dark violet color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/9300D3">9300D3</see>.</returns>
        VioletDark = 0x9300D3,

        /// <summary>
        /// Gets the light violet color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/7A5199">7A5199</see>.</returns>
        VioletLight = 0x7A5199,

        /// <summary>
        /// Gets the white color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/F2F2F2">F2F2F2</see>.</returns>
        White = 0xF2F2F2,

        /// <summary>
        /// Gets the absolute white color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFFFFF">FFFFFF</see>.</returns>
        WhiteAbsolute = 0xFFFFFF,

        /// <summary>
        /// Gets the yellow color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFCC00">FFCC00</see>.</returns>
        Yellow = 0xFFCC00,

        /// <summary>
        /// Gets the dark yellow color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFFFCC">FFFFCC</see>.</returns>
        YellowDark = 0xFFFFCC,

        /// <summary>
        /// Gets the light yellow color value.
        /// </summary>
        /// <returns>A color struct with the hex value of <see href="http://www.color-hex.com/color/FFFFED">FFFFED</see>.</returns>
        YellowLight = 0xFFFFED,
    }
}