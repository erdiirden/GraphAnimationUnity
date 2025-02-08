using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JsonReader : MonoBehaviour
{
    int year = 1956;
    public Text sezon, kupaAdi, takimAdi;
    int Besiktas, Fenerbahce, Galatasaray, Trabzonspor, Ankaragucu, Goztepe, Bursaspor, Altay, Genclerbirligi, Kocaelispor, Eskisehirspor, Konyaspor, Akhisar, Kayserispor, Basaksehir, Sakaryaspor, Sivasspor = 0;
    public Image logo;
    public Sprite[] logoGorselleri;
    string winTemp = "bos";
    public AudioClip[] marslar;
    public AudioSource audioSource;
    public Slider[] sliders;
    public Text[] sliderTakimAdi; 
    public Text[] sliderKupaSayisi; 
    public Image[] sliderLogo;
    public Sprite[] sliderSprite; 
    int toplamKupa = 0;
    public Image kupaFoto;
    public Sprite[] kupaFotoGorselleri;

    void Start()
    {
        StartCoroutine(LoadSeasons()); // Sezonlarý baþlatmak için coroutine çaðýrýyoruz.
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator LoadSeasons()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("veri"); // "Resources/veri.json" okunur
        if (jsonFile != null)
        {
            SeasonData seasonData = JsonUtility.FromJson<SeasonData>(jsonFile.text);
            Debug.Log("JSON Baþarýyla Okundu!");

            if (seasonData.seasons.Count > 0)
            {
                for (int i = 0; i < 68; i++) // 0'dan 67'ye kadar gitmek için < 68
                {
                    sezon.text = year.ToString();

                    Debug.Log(seasonData.seasons[i].season + ". Sezon Süper Lig Kazananý: " + seasonData.seasons[i].cups[0].winner);
                    kupaAdi.text = "SÜPER LÝG";
                    kupaFoto.sprite =kupaFotoGorselleri[0];
                    takimAdi.text = seasonData.seasons[i].cups[0].winner.ToString();
                    winTemp = seasonData.seasons[i].cups[0].winner.ToString();
                    logoveSayac();
                    if (winTemp != "DÜZENLENMEDÝ")
                    {
                        yield return StartCoroutine(GetCup());
                    }

                    Debug.Log(seasonData.seasons[i].season + ". Sezon Türkiye Kupasý Kazananý: " + seasonData.seasons[i].cups[1].winner);
                    kupaAdi.text = "TÜRKÝYE KUPASI";
                    kupaFoto.sprite = kupaFotoGorselleri[1];
                    takimAdi.text = seasonData.seasons[i].cups[1].winner.ToString();
                    winTemp = seasonData.seasons[i].cups[1].winner.ToString();
                    logoveSayac();
                    if (winTemp != "DÜZENLENMEDÝ")
                    {
                        yield return StartCoroutine(GetCup());
                    }

                    Debug.Log(seasonData.seasons[i].season + ". Sezon TFF Süper Kupasý Kazananý: " + seasonData.seasons[i].cups[2].winner);
                    kupaAdi.text = "TFF SÜPER KUPA";
                    kupaFoto.sprite = kupaFotoGorselleri[2];
                    takimAdi.text = seasonData.seasons[i].cups[2].winner.ToString();
                    winTemp = seasonData.seasons[i].cups[2].winner.ToString();
                    logoveSayac();
                    if (winTemp != "DÜZENLENMEDÝ")
                    {
                        yield return StartCoroutine(GetCup());
                    }

                    year++;

                    if (i >= 68)
                    {
                        Debug.Log("DURDUR");
                    }
                }
            }
            else
            {
                Debug.Log("BÝTTÝ--Sezon verisi yetersiz! 68 sezon olmalý.");
            }
        }
        else
        {
            Debug.LogError(" JSON dosyasý bulunamadý! 'Resources/veri.json' var mý?");
        }
    }

    IEnumerator GetCup()
    {
        // 2 saniye bekle
        yield return new WaitForSeconds(5f);

        // Gecikme sonrasý yapýlacak iþlemler
        Debug.Log("Gecikme ile çalýþtýrýldý!");
    }
    void logoveSayac()
    {
        switch (winTemp)
        {
            case "Akhisar":
                Akhisar++;
                logo.sprite = logoGorselleri[0];
                audioSource.PlayOneShot(marslar[0]);
                toplamKupa++;
                //AkhisarSlider();
                break;
            case "Altay":
                Altay++;
                logo.sprite = logoGorselleri[1];
                audioSource.PlayOneShot(marslar[1]);
                toplamKupa++;
                //AltaySlider();
                break;
            case "Ankaragucu":
                Ankaragucu++;
                logo.sprite = logoGorselleri[2];
                audioSource.PlayOneShot(marslar[2]);
                toplamKupa++;
                //AnkaragucuSlider();
                break;
            case "Basaksehir":
                Basaksehir++;
                logo.sprite = logoGorselleri[3];
                audioSource.PlayOneShot(marslar[3]);
                toplamKupa++;
                //BasaksehirSlider(); 
                break;
            case "Besiktas":
                Besiktas++;
                logo.sprite = logoGorselleri[4];
                audioSource.PlayOneShot(marslar[4]);
                toplamKupa++;
                //BesiktasSlider();
                break;
            case "Bursaspor":
                Bursaspor++;
                logo.sprite = logoGorselleri[5];
                audioSource.PlayOneShot(marslar[5]);
                toplamKupa++;
                //BursasporSlider();
                break;
            case "Eskisehirspor":
                Eskisehirspor++;
                logo.sprite = logoGorselleri[6];
                audioSource.PlayOneShot(marslar[6]);
                toplamKupa++;
                //EskisehirsporSlider();
                break;
            case "Fenerbahce":
                Fenerbahce++;
                logo.sprite = logoGorselleri[7];
                audioSource.PlayOneShot(marslar[7]);
                toplamKupa++;
                //FenerbahceSlider();
                break;
            case "Galatasaray":
                Galatasaray++;
                logo.sprite = logoGorselleri[8];
                audioSource.PlayOneShot(marslar[8]);
                toplamKupa++;
                //GalatasaraySlider();
                break;
            case "Genclerbirligi":
                Genclerbirligi++;
                logo.sprite = logoGorselleri[9];
                audioSource.PlayOneShot(marslar[9]);
                toplamKupa++;
                //GenclerbirligiSlider();
                break;
            case "Goztepe":
                Goztepe++;
                logo.sprite = logoGorselleri[10];
                audioSource.PlayOneShot(marslar[10]);
                toplamKupa++;
                //GoztepeSlider();
                break;
            case "Kayserispor":
                Kayserispor++;
                logo.sprite = logoGorselleri[11];
                audioSource.PlayOneShot(marslar[11]);
                toplamKupa++;
                //KayserisporSlider();
                break;
            case "Kocaelispor":
                Kocaelispor++;
                logo.sprite = logoGorselleri[12];
                audioSource.PlayOneShot(marslar[12]);
                toplamKupa++;
                //KocaelisporSlider();
                break;
            case "Konyaspor":
                Konyaspor++;
                logo.sprite = logoGorselleri[13];
                audioSource.PlayOneShot(marslar[13]);
                toplamKupa++;
                //KonyasporSlider();
                break;
            case "Sakaryaspor":
                Sakaryaspor++;
                logo.sprite = logoGorselleri[14];
                audioSource.PlayOneShot(marslar[14]);
                toplamKupa++;
                //SakaryasporSlider();
                break;
            case "Sivasspor":
                Sivasspor++;
                logo.sprite = logoGorselleri[15];
                audioSource.PlayOneShot(marslar[15]);
                toplamKupa++;
                //SivassporSlider();
                break;
            case "Trabzonspor":
                Trabzonspor++;
                logo.sprite = logoGorselleri[16];
                audioSource.PlayOneShot(marslar[16]);
                toplamKupa++;
                //TrabzonsporSlider();
                break;
            case "DÜZENLENMEDÝ":
                logo.sprite = logoGorselleri[17];
                break;
            default:
                Console.WriteLine("Bilinmeyen takým");
                break;
        }
    }
    private void Update()
    {
        Debug.Log("Galatasaray: " + Galatasaray);
        Debug.Log("Beþiktaþ: " + Besiktas);
        Debug.Log("Fenerbahçe: " + Fenerbahce);
        Debug.Log(Trabzonspor + "" + Ankaragucu + "" + Goztepe + "" + Bursaspor + "" + Altay + "" + Genclerbirligi + "" + Kocaelispor + "" + Eskisehirspor + "" + "" + Konyaspor + "" + Akhisar + "" + Kayserispor + "" + Basaksehir + "" + Sakaryaspor + "" + Sivasspor);
        
        
        
        
    }

    private void LateUpdate()
    {
        AkhisarSlider();
        AltaySlider();
        AnkaragucuSlider();
        BasaksehirSlider();
        BesiktasSlider();
        BursasporSlider();
        EskisehirsporSlider();
        FenerbahceSlider();
        GalatasaraySlider();
        GenclerbirligiSlider();
        GoztepeSlider();
        KayserisporSlider();
        KocaelisporSlider();
        KonyasporSlider();
        SakaryasporSlider();
        SivassporSlider();
        TrabzonsporSlider();
        SýralýSliderGuncelle();
    }


    void SýralýSliderGuncelle()
    {
        List<Slider> sliderList = sliders.ToList(); // Sliderlarý listeye al
        sliderList.Sort((a, b) => b.value.CompareTo(a.value)); // Büyükten küçüðe sýrala

        float startY = -21f; // Baþlangýç Y pozisyonu (Canvas’a göre ayarlayabilirsiniz)
        float offsetY = 35.3f; // Her slider arasý boþluk mesafesi

        for (int i = 0; i < sliderList.Count; i++)
        {
            RectTransform rt = sliderList[i].GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, startY - (i * offsetY)); // Yeni konumu ayarla
        }
    }

    void AkhisarSlider()
    {

        if (Akhisar > 0)
        {
            // Slider[0]'ýn dolum rengini siyah yap
            Image fillImage = sliders[0].fillRect.GetComponent<Image>();
            fillImage.color = Color.green;
            //slider ilerleme oraný
            float oran = (float)Akhisar / (float)toplamKupa;
            sliders[0].value = oran;
            //kupa sayýsý
            sliderKupaSayisi[0].text = Akhisar.ToString();
            //logo
            sliderLogo[0].sprite = sliderSprite[0];
            sliderTakimAdi[0].text = "AKHÝSAR";
        }

    }
    void AltaySlider()
    {
        if (Altay>0)
        {
            Image fillImage = sliders[1].fillRect.GetComponent<Image>();
            fillImage.color = Color.black;
            float oran = (float)Altay / (float)toplamKupa;
            sliders[1].value = oran;
            sliderKupaSayisi[1].text = Altay.ToString();
            sliderLogo[1].sprite = sliderSprite[1];
            sliderTakimAdi[1].text = "ALTAY";
        }
    }
    void AnkaragucuSlider()
    {
        if (Ankaragucu>0)
        {
            Image fillImage = sliders[2].fillRect.GetComponent<Image>();
            fillImage.color = Color.yellow;
            float oran = (float)Ankaragucu / (float)toplamKupa;
            sliders[2].value = oran;
            sliderKupaSayisi[2].text = Ankaragucu.ToString();
            sliderLogo[2].sprite = sliderSprite[2];
            sliderTakimAdi[2].text = "ANKARAGÜCÜ";
        }
    }
    void BasaksehirSlider()
    {
        if (Basaksehir>0)
        {
            Image fillImage = sliders[3].fillRect.GetComponent<Image>();
            fillImage.color = Color.blue;
            float oran = (float)Basaksehir / (float)toplamKupa;
            sliders[3].value = oran;
            sliderKupaSayisi[3].text = Basaksehir.ToString();
            sliderLogo[3].sprite = sliderSprite[3];
            sliderTakimAdi[3].text = "BAÞAKÞEHÝR";
        }
    }
    void BesiktasSlider()
    {
        if (Besiktas>0)
        {
            Image fillImage = sliders[4].fillRect.GetComponent<Image>();
            fillImage.color = Color.black;
            float oran = (float)Besiktas / (float)toplamKupa;
            sliders[4].value = oran;
            sliderKupaSayisi[4].text = Besiktas.ToString();
            sliderLogo[4].sprite = sliderSprite[4];
            sliderTakimAdi[4].text = "BEÞÝKTAÞ";
        }
    }
    void BursasporSlider()
    {
        if (Bursaspor>0)
        {
            Image fillImage = sliders[5].fillRect.GetComponent<Image>();
            fillImage.color = Color.green;
            float oran = (float)Bursaspor / (float)toplamKupa;
            sliders[5].value = oran;
            sliderKupaSayisi[5].text = Bursaspor.ToString();
            sliderLogo[5].sprite = sliderSprite[5];
            sliderTakimAdi[5].text = "BURSASPOR";
        }
    }
    void EskisehirsporSlider()
    {
        if (Eskisehirspor>0)
        {
            Image fillImage = sliders[6].fillRect.GetComponent<Image>();
            fillImage.color = Color.yellow;
            float oran = (float)Eskisehirspor / (float)toplamKupa;
            sliders[6].value = oran;
            sliderKupaSayisi[6].text = Eskisehirspor.ToString();
            sliderLogo[6].sprite = sliderSprite[6];
            sliderTakimAdi[6].text = "ESKÝÞEHÝRSPOR";
        }
    }
    void FenerbahceSlider()
    {
        if (Fenerbahce>0)
        {
            Image fillImage = sliders[7].fillRect.GetComponent<Image>();
            fillImage.color = Color.yellow;
            float oran = (float)Fenerbahce / (float)toplamKupa;
            sliders[7].value = oran;
            sliderKupaSayisi[7].text = Fenerbahce.ToString();
            sliderLogo[7].sprite = sliderSprite[7];
            sliderTakimAdi[7].text = "FENERBAHÇE";
        }
    }
    void GalatasaraySlider()
    {
        if (Galatasaray>0)
        {
            Image fillImage = sliders[8].fillRect.GetComponent<Image>();
            fillImage.color = Color.red;
            float oran = (float)Galatasaray / (float)toplamKupa;
            sliders[8].value = oran;
            sliderKupaSayisi[8].text = Galatasaray.ToString();
            sliderLogo[8].sprite = sliderSprite[8];
            sliderTakimAdi[8].text = "GALATASARAY";
        }
    }
    void GenclerbirligiSlider()
    {
        if (Genclerbirligi>0)
        {
            Image fillImage = sliders[9].fillRect.GetComponent<Image>();
            fillImage.color = Color.red;
            float oran = (float)Genclerbirligi / (float)toplamKupa;
            sliders[9].value = oran;
            sliderKupaSayisi[9].text = Genclerbirligi.ToString();
            sliderLogo[9].sprite = sliderSprite[9];
            sliderTakimAdi[9].text = "GENÇLERBÝRLÝÐÝ";
        }
    }
    void GoztepeSlider()
    {
        if (Goztepe>0)
        {
            Image fillImage = sliders[10].fillRect.GetComponent<Image>();
            fillImage.color = Color.red;
            float oran = (float)Goztepe / (float)toplamKupa;
            sliders[10].value = oran;
            sliderKupaSayisi[10].text = Goztepe.ToString();
            sliderLogo[10].sprite = sliderSprite[10];
            sliderTakimAdi[10].text = "GOZTEPE";
        }
    }
    void KayserisporSlider()
    {
        if (Kayserispor>0)
        {
            Image fillImage = sliders[11].fillRect.GetComponent<Image>();
            fillImage.color = Color.yellow;
            float oran = (float)Kayserispor / (float)toplamKupa;
            sliders[11].value = oran;
            sliderKupaSayisi[11].text = Kayserispor.ToString();
            sliderLogo[11].sprite = sliderSprite[11];
            sliderTakimAdi[11].text = "KAYSERÝSPOR";
        }
    }
    void KocaelisporSlider()
    {
        if (Kocaelispor>0)
        {
            Image fillImage = sliders[12].fillRect.GetComponent<Image>();
            fillImage.color = Color.green;
            float oran = (float)Kocaelispor / (float)toplamKupa;
            sliders[12].value = oran;
            sliderKupaSayisi[12].text = Kocaelispor.ToString();
            sliderLogo[12].sprite = sliderSprite[12];
            sliderTakimAdi[12].text = "KOCAELÝSPOR";
        }
    }
    void KonyasporSlider()
    {
        if (Konyaspor>0)
        {
            Image fillImage = sliders[13].fillRect.GetComponent<Image>();
            fillImage.color = Color.green;
            float oran = (float)Konyaspor / (float)toplamKupa;
            sliders[13].value = oran;
            sliderKupaSayisi[13].text = Konyaspor.ToString();
            sliderLogo[13].sprite = sliderSprite[13];
            sliderTakimAdi[13].text = "KONYASPOR";
        }
    }
    void SakaryasporSlider()
    {
        if (Sakaryaspor>0)
        {
            Image fillImage = sliders[14].fillRect.GetComponent<Image>();
            fillImage.color = Color.green;
            float oran = (float)Sakaryaspor / (float)toplamKupa;
            sliders[14].value = oran;
            sliderKupaSayisi[14].text = Sakaryaspor.ToString();
            sliderLogo[14].sprite = sliderSprite[14];
            sliderTakimAdi[14].text = "SAKARYASPOR";
        }
    }
    void SivassporSlider()
    {
        if (Sivasspor>0)
        {
            Image fillImage = sliders[15].fillRect.GetComponent<Image>();
            fillImage.color = Color.red;
            float oran = (float)Sivasspor / (float)toplamKupa;
            sliders[15].value = oran;
            sliderKupaSayisi[15].text = Sivasspor.ToString();
            sliderLogo[15].sprite = sliderSprite[15];
            sliderTakimAdi[15].text = "SÝVASSPOR";
        }
    }
    void TrabzonsporSlider()
    {
        if (Trabzonspor>0)
        {
            Image fillImage = sliders[16].fillRect.GetComponent<Image>();
            fillImage.color = Color.blue;
            float oran = (float)Trabzonspor / (float)toplamKupa;
            sliders[16].value = oran;
            sliderKupaSayisi[16].text = Trabzonspor.ToString();
            sliderLogo[16].sprite = sliderSprite[16];
            sliderTakimAdi[16].text = "TRABZONSPOR";
        }
    }
}
