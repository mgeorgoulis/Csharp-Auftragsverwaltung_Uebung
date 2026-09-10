using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Auftrag
{
    public String Auftragsnummer { get; private set; }
    public String Kunde{get; private set;}
    public double Gewicht {get; private set;}
    public bool AuftragAbgeschlossen {get; private set;}
    
    

    public Auftrag(
        string auftragsnummer,
        string kunde,
        double gewicht,
        bool auftragAbgeschlossen)
    {
        Auftragsnummer = auftragsnummer;
        Kunde = kunde;
        Gewicht = gewicht;
        AuftragAbgeschlossen = auftragAbgeschlossen;

    }

    public string StatusPruefen()
    {
        if (!AuftragAbgeschlossen)
        {
            return ("Offen");
        }
        else
        {
            return ("Abgeschlossen");
        }
    }

    public void AuftragAbschliessen()
    {
        if (AuftragAbgeschlossen == false)
        {
            AuftragAbgeschlossen = true;
            Console.WriteLine($"Auftrag {Auftragsnummer} wurde erfolgreich abgeschlossen.");
        }
        else
        {
            Console.WriteLine($"Auftrag {Auftragsnummer} ist bereits geschlossen.");
        }
    }

    public void GewichtAendern(double neuesGewicht)
    {
        
        if (neuesGewicht > 0)
        {
            Gewicht = neuesGewicht;
            Console.WriteLine($"Das Gewicht des Auftrags {Auftragsnummer} wurde auf den Wert von {Gewicht} kg geändert.");
        }
        else
        {
            throw new ArgumentOutOfRangeException("Der eingegebene Wert ist ungültig.");
        }
    }

    public double VersandkostenBerechnen()
    {
      if (Gewicht <= 100)
        {
            return 20d;
        }
        else
        {
            return 35d;
        }
    }

    public bool IstSchwerlast()
    {
        return Gewicht > 250; 
    }

    public bool KannVersendetWerden()
    {
       return AuftragAbgeschlossen && Gewicht >0;
    }

    public string GewichtsklasseErmitteln()
    {
        if (Gewicht <= 100)
        {
            return "Leicht";
        }else if (Gewicht <= 250)
        {
            return "Mittel";
        }else
        {
            return "Schwerlast";
        }
    }

    public double TransportpreisBerechnen(double preisProKg, double grundgebuehr)
    {
        if (preisProKg <= 0)
        {
            throw new ArgumentOutOfRangeException
            (
                nameof(preisProKg),
                "Der Kilogramm-Preis muss einen Wert enthalten der größer Null ist."  
            );
        } else if (grundgebuehr < 0)
        {
            throw new ArgumentOutOfRangeException
            (
                nameof(grundgebuehr),
                "Die Grundgebühr darf keinen negativen Wert besitzen."
            );
        } 
        
        double transportpreis = Gewicht * preisProKg + grundgebuehr; 
        return Math.Round(transportpreis,2);
            
    }  

    




}  // Ende der Klasse!!
  
    
      
        
        
        
        
        
        
        
        
        
    

