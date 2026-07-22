using Interfaces.ex1.Models;

namespace Interfaces.ex1
{
    public class Testare
    {
        public Testare()
        {
            Telecomanda telecomanda = new();

            Bec bec = new();
            Priza priza = new();
            Termostat termostat = new();
            SenzorTemperatura senzor = new(20);
            Boxa boxa = new();

            IRaportor[] raportors = new IRaportor[5];
            raportors[0] = bec;
            raportors[1] = priza;
            raportors[2] = termostat;
            raportors[3] = senzor;
            raportors[4] = boxa;

            IReglabil[] reglabils = new IReglabil[3];
            reglabils[0] = bec;
            reglabils[1] = termostat;
            reglabils[2] = boxa;

            IPornibil[] pornibils = new IPornibil[3];
            pornibils[0] = bec;
            pornibils[1] = priza;
            pornibils[2] = boxa;

            bec.Porneste();
            priza.Porneste();
            boxa.Porneste();

            bec.SeteazaIntensitate(50);
            termostat.SeteazaIntensitate(22);
            boxa.SeteazaIntensitate(40);

            telecomanda.RaportGeneral(raportors);

            telecomanda.ModNoapte(reglabils);
            telecomanda.StingeTot(pornibils);

            telecomanda.RaportGeneral(raportors);
        }
    }
}