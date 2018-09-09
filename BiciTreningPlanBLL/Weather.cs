using BiciTrainingPlanDAL;
using CyclingTrainingPlan.Model;
using Newtonsoft.Json;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class Weather
    {
        private List<Vreme> Vreme;
        public void GetWeatherFromServer()
        {
            string appId = "c6f05e0aa3aacd122f5709272fdd2251";
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?id={0}&appid={1}&units=metric", "789128", appId);
            FormatWeather(url);
        }

        private void FormatWeather(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(downloadedString);
                    client.DownloadStringAsync(new Uri(url));
                }
                catch (TargetInvocationException ex)
                {
                    throw new TargetInvocationException(ex);
                }
            }
        }

        private void downloadedString(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                WeatherModel model = JsonConvert.DeserializeObject<WeatherModel>(e.Result);

                Vreme = GetTop6();

                for (int i = 0; i < model.list.Count(); i++)
                {
                    string datum = Convert.ToDateTime(model.list[i].dt_txt).ToString();
                    bool check = i == 0 ? true : datum.Contains("12:00:00");                    
                    foreach (var vreme in Vreme)
                    {
                        if (!CheckDate(datum) && check)
                        {
                            Vreme vr = new Vreme();
                            vr.Datum = Convert.ToDateTime(model.list[i].dt_txt);
                            vr.Temperatura = (int)model.list[i].main.temp;
                            vr.Smer_vetra = (int)model.list[i].wind.deg;
                            vr.Brzina_vetra = (int)model.list[i].wind.speed;
                            vr.Vlaznost_vazduha = model.list[i].main.humidity;
                            vr.Oblacnost = model.list[i].clouds.all;
                            vr.Slika = "http://openweathermap.org/img/w/" + model.list[i].weather[0].icon + ".png";
                            vr.Opis = ConvertOpis(model.list[i].weather[0].id);
                            vr.ID_Grada = model.city.id;

                            VremeManipulator vremeManipulator = new VremeManipulator();
                            vremeManipulator.Insert(vr);

                            Vreme = GetTop6();
                        }

                    }

                }
                foreach (var danasnjeVreme in model.list)
                {

                }
            }
            catch (TargetInvocationException ex)
            {
                //         throw new TargetInvocationException(ex);
            }
        }

        private bool CheckDate(string date)
        {
            //Upisati samo kada je date = date + 12:00:00 /AM
            bool returnValue = false;

            if (Vreme != null)
            {
                foreach (var vreme in Vreme)
                {
                    string shortDateDB = vreme.Datum.ToString();
                    string shortDateWeather = Convert.ToDateTime(date).ToString();
                    if (shortDateDB == date)
                        return true;
                    //   if(date == )
                    //  if(vreme.Datum.ToString() == shortDate)
                }
            }
            //if (date == (Convert.ToDateTime(date).ToShortDateString() + ""))
            //    return true;

            return returnValue;
        }

        private string ConvertOpis(int id)
        {
            switch (id)
            {
                case 200:
                case 201:
                case 202:
                case 210:
                case 211:
                case 212:
                case 230:
                case 231:
                case 232:
                    return "NEVREME SA GRMLJAVINOM";
                case 300:
                case 301:
                case 302:
                case 310:
                case 311:
                case 312:
                case 313:
                case 314:
                case 321:
                    return "SLABA KIŠA";
                case 500:
                case 501:
                case 502:
                case 503:
                case 504:
                case 511:
                case 520:
                case 521:
                case 522:
                case 531:
                    return "KIŠA";
                case 600:
                case 601:
                case 602:
                case 611:
                case 612:
                case 615:
                case 616:
                case 620:
                case 621:
                case 622:
                    return "SNEG";
                case 701:
                    return "IZMAGLICA";
                case 711:
                    return "DIM";
                case 721:
                    return "MAGLA";
                case 731:
                    return "PESAK, PRAŠINA";
                case 741:
                    return "MAGLA";
                case 751:
                    return "PESAK";
                case 761:
                    return "PRAŠINA";
                case 762:
                    return "VULKANSKI PEPEO";
                case 771:
                    return "JAK UDAR VETRA";
                case 781:
                    return "TORNADO";
                case 800:
                    return "VEDRO";
                case 801:
                case 802:
                case 803:
                    return "MALO OBLAKA";
                case 804:
                    return "PRETEŽNO OBLAČNO";
                default:
                    return "N/A";
            }
        }

        public List<Vreme> GetTop6()
        {
            VremeManipulator vreme = new VremeManipulator();
            try
            {
                return vreme.GetData().OrderByDescending(o => o.Datum).Take(6).ToList();
            }
            catch
            {
                return new List<Vreme>() { new Vreme(), new Vreme(), new Vreme(), new Vreme(), new Vreme() };
            }
        }
    }
}