namespace Interfaces.ex1.Models
{
    public class Telecomanda
    {
        public void StingeTot(IPornibil[] dispozitive)
        {
            for(int i = 0; i  < dispozitive.Length; i++)
            {
                dispozitive[i].Opreste();
            }
        }

        public void ModNoapte(IReglabil[] dispozitive)
        {
            for(int i = 0; i < dispozitive.Length; i++)
            {
                dispozitive[i].SeteazaIntensitateMinima();
            }
        }

        public void RaportGeneral(IRaportor[] dispozitive)
        {
            for(int i = 0; i < dispozitive.Length; i++)
            {
                Console.WriteLine(dispozitive[i].Stare());
            }
        }
    }
}