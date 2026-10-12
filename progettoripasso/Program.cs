namespace progettoripasso
{
	internal class Program
	{
	    static void Cercarticolo(List<string> codice, List<string> descrizione, List<int> quantita, List<double> prezzo)
		{
			Console.WriteLine("inserisci il codice dell'articolo da cercare");
			string codicedacercare = Console.ReadLine();
			bool trovato= false;	
			for (int i = 0; i < codice.Count; i++)
			{
				if (codice[i].Contains(codicedacercare))
				{
					Console.WriteLine($"codice: {codice[i]} | prodotto: {descrizione[i]} | qta: {quantita[i]} | prezzo: {prezzo[i]} €");
					trovato = true;
					
				}
				
			}
			if (!trovato)
			{
				Console.WriteLine("articolo non trovato");
			}

		}
		static void scaricarticolo(List<string> codice, List<string> descrizione, List<int> quantita, List<double> prezzo)
		{
			Console.WriteLine("inserisci il codice dell'articolo da scaricare");
			string codicedascaricare = Console.ReadLine();
			bool trovato= false;	
			for (int i = 0; i < codice.Count; i++)
			{
				if (codice[i].Contains(codicedascaricare))
				{
					trovato = true;
					
				}
				else
				{ 					
				   Console.WriteLine("articolo non trovato");
				}
				if(trovato) 
				{
					
					Console.WriteLine("inserisci la quantita da scaricare");
					int quantitascaricata = int.Parse(Console.ReadLine());
					if (quantitascaricata <= quantita[i])
					{
						quantita[i] =quantita[i]- quantitascaricata;
						Console.WriteLine($"quantità aggiornata {quantita[i - 1]}");
					}
					else
					{
						Console.WriteLine("quantità insufficiente per lo scarico");
					}
				}
			}
		}
		static void Main(string[] args)
		{
			string percorsoCsv = "articoli.csv";
			List<string> codice = new List<string>();
			List<string> descrizione = new List<string>();
			List<int> quantita = new List<int>();
			List<double> prezzo = new List<double>();

			if (File.Exists(percorsoCsv))
			{
				
				string[] righe = File.ReadAllLines(percorsoCsv);
				
				for (int i = 1; i < righe.Length; i++)
				{
					string[] categorie = righe[i].Split(';');
					codice.Add(categorie[0]);
					descrizione.Add(categorie[1]);
					quantita.Add(int.Parse(categorie[2]));
					prezzo.Add(double.Parse(categorie[3]));

					Console.WriteLine($"codice: {codice[i-1]}  prodotto: {descrizione[i-1]}  qta: {quantita[i - 1	]} prezzo: {prezzo[i - 1]} €");
				}
			}
			else
			{
				Console.WriteLine("File CSV non trovato.");
			}
			Console.WriteLine("MENU MAGAZZINO");	
			Console.WriteLine("1= cerca articoli");
			Console.WriteLine("2= scarica quantita per vendita");
			int scelta=int.Parse(Console.ReadLine());
			if ( scelta == 1 )	
			{ 
			       Cercarticolo(codice, descrizione, quantita, prezzo);
			}
			else if(scelta==2)
			{ 
			          scaricarticolo(codice, descrizione, quantita, prezzo);
			}
		}
	}
}
