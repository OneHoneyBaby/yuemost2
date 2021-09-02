using DSkin.Html.Adapters;
using DSkin.Html.Core;
using DSkin.Html.Core.Dom;
using DSkin.Html.Core.Entities;
using DSkin.Html.Core.Handlers;
using DSkin.Html.Core.Utils;
using System;
using System.Globalization;
using System.IO;

internal sealed class Class36 : IDisposable
{
    private CssBox cssBox_0;
    private CssRect cssRect_0;
    private readonly HtmlContainerInt htmlContainerInt_0;
    private RContextMenu rcontextMenu_0;
    private RControl rcontrol_0;
    private readonly SelectionHandler selectionHandler_0;
    private static readonly string string_0;
    private static readonly string string_1;
    private static readonly string string_2;
    private static readonly string string_3;
    private static readonly string string_4;
    private static readonly string string_5;
    private static readonly string string_6;
    private static readonly string string_7;
    private static readonly string string_8;

    static Class36()
    {
        if (CultureInfo.CurrentUICulture.Name.StartsWith("fr", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "Tout s\x00e9lectionner";
            string_1 = "Copier";
            string_2 = "Copier l'adresse du lien";
            string_3 = "Ouvrir le lien";
            string_4 = "Copier l'URL de l'image";
            string_5 = "Copier l'image";
            string_6 = "Enregistrer l'image sous...";
            string_7 = "Ouvrir la vid\x00e9o";
            string_8 = "Copier l'URL de l'vid\x00e9o";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("de", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "Alle ausw\x00e4hlen";
            string_1 = "Kopieren";
            string_2 = "Link-Adresse kopieren";
            string_3 = "Link \x00f6ffnen";
            string_4 = "Bild-URL kopieren";
            string_5 = "Bild kopieren";
            string_6 = "Bild speichern unter...";
            string_7 = "Video \x00f6ffnen";
            string_8 = "Video-URL kopieren";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("it", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "Seleziona tutto";
            string_1 = "Copia";
            string_2 = "Copia indirizzo del link";
            string_3 = "Apri link";
            string_4 = "Copia URL immagine";
            string_5 = "Copia immagine";
            string_6 = "Salva immagine con nome...";
            string_7 = "Apri il video";
            string_8 = "Copia URL video";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("es", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "Seleccionar todo";
            string_1 = "Copiar";
            string_2 = "Copiar direcci\x00f3n de enlace";
            string_3 = "Abrir enlace";
            string_4 = "Copiar URL de la imagen";
            string_5 = "Copiar imagen";
            string_6 = "Guardar imagen como...";
            string_7 = "Abrir video";
            string_8 = "Copiar URL de la video";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("ru", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "Выбрать все";
            string_1 = "Копировать";
            string_2 = "Копировать адрес ссылки";
            string_3 = "Перейти по ссылке";
            string_4 = "Копировать адрес изображения";
            string_5 = "Копировать изображение";
            string_6 = "Сохранить изображение как...";
            string_7 = "Открыть видео";
            string_8 = "Копировать адрес видео";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("sv", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "V\x00e4lj allt";
            string_1 = "Kopiera";
            string_2 = "Kopiera l\x00e4nkadress";
            string_3 = "\x00d6ppna l\x00e4nk";
            string_4 = "Kopiera bildens URL";
            string_5 = "Kopiera bild";
            string_6 = "Spara bild som...";
            string_7 = "\x00d6ppna video";
            string_8 = "Kopiera video URL";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("hu", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "\x00d6sszes kiv\x00e1laszt\x00e1sa";
            string_1 = "M\x00e1sol\x00e1s";
            string_2 = "Hivatkoz\x00e1s c\x00edm\x00e9nek m\x00e1sol\x00e1sa";
            string_3 = "Hivatkoz\x00e1s megnyit\x00e1sa";
            string_4 = "K\x00e9p URL m\x00e1sol\x00e1sa";
            string_5 = "K\x00e9p m\x00e1sol\x00e1sa";
            string_6 = "K\x00e9p ment\x00e9se m\x00e1sk\x00e9nt...";
            string_7 = "Vide\x00f3 megnyit\x00e1sa";
            string_8 = "Vide\x00f3 URL m\x00e1sol\x00e1sa";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("cs", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "Vybrat vše";
            string_1 = "Kop\x00edrovat";
            string_2 = "Kop\x00edrovat adresu odkazu";
            string_3 = "Otevř\x00edt odkaz";
            string_4 = "Kop\x00edrovat URL sn\x00edmku";
            string_5 = "Kop\x00edrovat sn\x00edmek";
            string_6 = "Uložit sn\x00edmek jako...";
            string_7 = "Otevř\x00edt video";
            string_8 = "Kop\x00edrovat URL video";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("da", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "V\x00e6lg alt";
            string_1 = "Kopi\x00e9r";
            string_2 = "Kopier link-adresse";
            string_3 = "\x00c5bn link";
            string_4 = "Kopier billede-URL";
            string_5 = "Kopier billede";
            string_6 = "Gem billede som...";
            string_7 = "\x00c5bn video";
            string_8 = "Kopier video-URL";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("nl", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "Alles selecteren";
            string_1 = "Kopi\x00ebren";
            string_2 = "Link adres kopi\x00ebren";
            string_3 = "Link openen";
            string_4 = "URL Afbeelding kopi\x00ebren";
            string_5 = "Afbeelding kopi\x00ebren";
            string_6 = "Bewaar afbeelding als...";
            string_7 = "Video openen";
            string_8 = "URL video kopi\x00ebren";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("fi", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "Valitse kaikki";
            string_1 = "Kopioi";
            string_2 = "Kopioi linkin osoite";
            string_3 = "Avaa linkki";
            string_4 = "Kopioi kuvan URL";
            string_5 = "Kopioi kuva";
            string_6 = "Tallena kuva nimell\x00e4...";
            string_7 = "Avaa video";
            string_8 = "Kopioi video URL";
        }
        else if (CultureInfo.CurrentUICulture.Name.StartsWith("zh", StringComparison.InvariantCultureIgnoreCase))
        {
            string_0 = "全选";
            string_1 = "复制";
            string_2 = "复制链接";
            string_3 = "打开链接";
            string_4 = "复制图片链接";
            string_5 = "复制图片";
            string_6 = "图片另存为";
            string_7 = "打开视频";
            string_8 = "复制视频链接";
        }
        else
        {
            string_0 = "Select all";
            string_1 = "Copy";
            string_2 = "Copy link address";
            string_3 = "Open link";
            string_4 = "Copy image URL";
            string_5 = "Copy image";
            string_6 = "Save image as...";
            string_7 = "Open video";
            string_8 = "Copy video URL";
        }
    }

    public Class36(SelectionHandler selectionHandler_1, HtmlContainerInt htmlContainerInt_1)
    {
        ArgChecker.AssertArgNotNull(selectionHandler_1, "selectionHandler");
        ArgChecker.AssertArgNotNull(htmlContainerInt_1, "htmlContainer");
        this.selectionHandler_0 = selectionHandler_1;
        this.htmlContainerInt_0 = htmlContainerInt_1;
    }

    public void Dispose()
    {
        this.method_1();
    }

    public void method_0(RControl rcontrol_1, CssRect cssRect_1, CssBox cssBox_1)
    {
        try
        {
            this.method_1();
            this.rcontrol_0 = rcontrol_1;
            this.cssRect_0 = cssRect_1;
            this.cssBox_0 = cssBox_1;
            this.rcontextMenu_0 = this.htmlContainerInt_0.method_0().GetContextMenu();
            if (cssRect_1 != null)
            {
                bool flag = false;
                if (cssBox_1 != null)
                {
                    flag = (cssBox_1 is Class24) && ((Class24) cssBox_1).method_24();
                    bool enabled = !string.IsNullOrEmpty(cssBox_1.HrefLink);
                    this.rcontextMenu_0.AddItem(flag ? string_7 : string_3, enabled, new EventHandler(this.method_2));
                    if (this.htmlContainerInt_0.IsSelectionEnabled)
                    {
                        this.rcontextMenu_0.AddItem(flag ? string_8 : string_2, enabled, new EventHandler(this.method_3));
                    }
                    this.rcontextMenu_0.AddDivider();
                }
                if (cssRect_1.IsImage && !flag)
                {
                    this.rcontextMenu_0.AddItem(string_6, cssRect_1.Image != null, new EventHandler(this.method_4));
                    if (this.htmlContainerInt_0.IsSelectionEnabled)
                    {
                        this.rcontextMenu_0.AddItem(string_4, !string.IsNullOrEmpty(this.cssRect_0.OwnerBox.GetAttribute("src")), new EventHandler(this.method_5));
                        this.rcontextMenu_0.AddItem(string_5, cssRect_1.Image != null, new EventHandler(this.method_6));
                    }
                    this.rcontextMenu_0.AddDivider();
                }
                if (this.htmlContainerInt_0.IsSelectionEnabled)
                {
                    this.rcontextMenu_0.AddItem(string_1, cssRect_1.Selected, new EventHandler(this.method_7));
                }
            }
            if (this.htmlContainerInt_0.IsSelectionEnabled)
            {
                this.rcontextMenu_0.AddItem(string_0, true, new EventHandler(this.method_8));
            }
            if (this.rcontextMenu_0.ItemsCount > 0)
            {
                this.rcontextMenu_0.RemoveLastDivider();
                this.rcontextMenu_0.Show(rcontrol_1, rcontrol_1.MouseLocation);
            }
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.ContextMenu, "Failed to show context menu", exception);
        }
    }

    private void method_1()
    {
        try
        {
            if (this.rcontextMenu_0 != null)
            {
                this.rcontextMenu_0.Dispose();
            }
            this.rcontextMenu_0 = null;
            this.rcontrol_0 = null;
            this.cssRect_0 = null;
            this.cssBox_0 = null;
        }
        catch
        {
        }
    }

    private void method_2(object sender, EventArgs e)
    {
        try
        {
            this.cssBox_0.HtmlContainer.method_9(this.rcontrol_0.MouseLocation, this.cssBox_0);
        }
        catch (HtmlLinkClickedException)
        {
            throw;
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.ContextMenu, "Failed to open link", exception);
        }
        finally
        {
            this.method_1();
        }
    }

    private void method_3(object sender, EventArgs e)
    {
        try
        {
            this.htmlContainerInt_0.method_0().SetToClipboard(this.cssBox_0.HrefLink);
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.ContextMenu, "Failed to copy link url to clipboard", exception);
        }
        finally
        {
            this.method_1();
        }
    }

    private void method_4(object sender, EventArgs e)
    {
        try
        {
            string attribute = this.cssRect_0.OwnerBox.GetAttribute("src");
            this.htmlContainerInt_0.method_0().SaveToFile(this.cssRect_0.Image, Path.GetFileName(attribute) ?? "image", Path.GetExtension(attribute) ?? "png", null);
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.ContextMenu, "Failed to save image", exception);
        }
        finally
        {
            this.method_1();
        }
    }

    private void method_5(object sender, EventArgs e)
    {
        try
        {
            this.htmlContainerInt_0.method_0().SetToClipboard(this.cssRect_0.OwnerBox.GetAttribute("src"));
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.ContextMenu, "Failed to copy image url to clipboard", exception);
        }
        finally
        {
            this.method_1();
        }
    }

    private void method_6(object sender, EventArgs e)
    {
        try
        {
            this.htmlContainerInt_0.method_0().SetToClipboard(this.cssRect_0.Image);
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.ContextMenu, "Failed to copy image to clipboard", exception);
        }
        finally
        {
            this.method_1();
        }
    }

    private void method_7(object sender, EventArgs e)
    {
        try
        {
            this.selectionHandler_0.CopySelectedHtml();
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.ContextMenu, "Failed to copy text to clipboard", exception);
        }
        finally
        {
            this.method_1();
        }
    }

    private void method_8(object sender, EventArgs e)
    {
        try
        {
            this.selectionHandler_0.SelectAll(this.rcontrol_0);
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.ContextMenu, "Failed to select all text", exception);
        }
        finally
        {
            this.method_1();
        }
    }
}

