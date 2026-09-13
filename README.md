# EmberMinimal

**EmberMinimal** is een C# console-applicatie voor het automatisch genereren van sterk-getypeerde C# klasse-definities op basis van de datastructuur van een actieve **Ember+** provider (via S101 over TCP). De applicatie maakt gebruik van het `Lawo.EmberPlusSharp` raamwerk om de Ember+ boomstructuur recursief te doorlopen en om te zetten naar C# code (`FieldNode<T>`) die direct gebruikt kan worden in databinding-modellen.

---

## 🚀 Key Features

* **Automatische C# Code-generatie:** Leest de Ember+ boomstructuur uit en genereert C# klassen (`FieldNode<T>`) met attributes (`[Element(Identifier = "...")]`).
* **Datatype Mapping:** Zet Ember+ parameter-datatypes automatisch om naar de juiste `Lawo.EmberPlusSharp.Model` types:
  * `Int64` ➔ `IntegerParameter`
  * `Boolean` ➔ `BooleanParameter`
  * `Double` ➔ `RealParameter`
  * `String` ➔ `StringParameter`
* **Recursieve Boomtraversal:** Navigeert via `WriteChildren` recursief door alle nodes en parameters van de Ember+ provider.
* **S101 TCP-Verbinding:** Maakt via `S101Client` een netwerkverbinding op poort `9000` met ondersteuning voor CRC-controle en keep-alive functionaliteit.
* **Duplicaat-preventie:** Gebruikt `HashSet` gegevensstructuren om dubbele klasses en eigenschap-definities te voorkomen.

---

## 📁 Code Structuur

| Component | Omschrijving |
| :--- | :--- |
| **`ConnectAsync`** | Opzetten van de TCP-verbinding en initialisatie van de `S101Client`. |
| **`WriteChildren`** | Recursieve methode die door de boomstructuur navigeert, unieke klassen verzamelt en eigenschappen analyseert. |
| **`DisplayClasses`** | Bouwt de gegenereerde C# klassen op en voert deze uit naar het consolescherm ter overname. |
| **`MyRoot`** | Minimale `DynamicRoot` klasse voor de initiële discovery op de provider. |

---

## 🛠️ Vereisten & Dependencies

* **Framework:** .NET Framework / .NET 6.0+ Console Application.
* **Bibliotheken:**
  * `Lawo.EmberPlusSharp`
  * `EmberLib.Glow`
* **Netwerk:** Een actieve Ember+ provider bereikbaar via `localhost:9000`.

---

## 🚀 Aan de slag

### 1. Provider starten
Zorg dat de Ember+ provider (of simulator) actief is op `localhost:9000`.

### 2. Project bouwen en uitvoeren
Open het project in Visual Studio of gebruik de .NET CLI:
```bash
dotnet run
