# EUC
## Online vstupní dotazník
Použité technologie
- .NET 9
- Entity Framework Core
- Automapper
- MSSQL
- Blazor
- MudBlazor UI
- xUnit

### Návod na rozbìhnutí
- Aktualizovat Visual Studio a nainstalovat .NET 9
- Rozbìhnout localdb, nebo v appsettings.json zmìnit connection string na jinou DB
- Spustit na MSSQL [master] databázi skript ze složky EUC_DB k vygenerování struktury DB
	- Alternativnì pouze založit DB [euc] a spustit migraci pøes EF Core
- Zkontrolovat stažení všech NuGet packages a ostatních dependencies projektu
- Buildnout a spustit projekt ze složky EUC

### Diskuse k zadání
Co bylo pøidáno, nebo upraveno oproti zadání a proè?

**Obrazovka Dotazník**
- Jazyk
	- Jazyk systému je øízen pomocí API controlleru, který nastavuje do cookie culture
	- Culture poté v celém systému øídí pøeklady, formáty datumù a podobnì
	- Pøeklady jsou øešeny pomocí Resources ve složce Locales
- Jméno a pøíjmení
	- Bylo oproti zadání rozdìleno na dvì pole (databázová normalizace)
- Rodné èíslo
	- Pøidána podpora pro nové zmìny RÈ v roce 2024, které v urèitých pøípadech umožòují pøidávat do sekce mìsíce RÈ +70 pro ženy a +20 pro muže
	- Pøidány validace:
		- Nevalidní znaky
		- Špatná pozice lomítka
		- Nesprávný poèet èíslic
		- Správnost datumové složky
		- Øešení pøesto neobsahuje 100% validátor RÈ, který by bylo nutno na produkèní verzi dùkladnì odladit
- Datum narození
	- Pøidány validace a omezení:
		- Nelze vybrat datum narození vyšší než je aktuální den
		- Není možné z datepickeru vybrat datum narození, pokud je vyplnìno RÈ
		- Pokud uživatel zadá RÈ, které obsahuje datum vyšší než aktuální den, toto datum se nepøedvyplní
- Pohlaví
	- Pøidány funkce:
		- Pøedvyplòuje se dle zadaného RÈ, ale nechává uživateli prostor zvolit jiné, nebo "Ostatní"
- Email
	- Pøidány validace:
		- Detekce mezer v adrese
		- Validce chybìjícího "@" znaku
		- Validce špatného formátu adresy
		- Validce problémù v lokální èásti adresy
		- Validce problémù v doménové èásti adresy
- Státní pøíslušnost
	- Pro zjednodušení pøidány pouze 3 (èeská, slovenská, ostatní)
- Souhlas s GDPR
	- Vyzkoušel jsem 2 varianty
		- Využití odkazu (a href s _blank targetem)
		- Druhou variantu - pøes API controller vracím soubor
	- Rozhodl jsem se pro API controller, protože je pak možné lépe øídit pøístup
	- API controller využívám i dále ke stažení JSONu (na produkci by bylo nutné øídit pøístup)
- Tlaèítko odeslat
	- Validuje znovu celý form klientsky
	- Pokud validace na klientovi selže, nedochází k volání servicy
	- Pokud validace projde, odesílají se data na servicu
	- V service se validují data ještì jednou pøed uložením do databáze
	- V pøípadì úspìšného uložení (vrátí se ID uloženého záznamu) je uživatel pøesunut na obrazovku Success, kde si mùže stáhnout JSON nebo vyplnit další formuláø
	- V pøípadì chyby vrací service jako result null a zobrazí se uživateli obrazovka Failed, kde se dozví, že operace uložení selhala a mùže zkusit vyplnit formuláø znovu

**Obrazovka Success**
- Po odeslání formuláøe a kladného scénáøe se zobrazí podìkování za odeslání formuláøe
- Na stránce lze stáhnout JSON s vyplnìnými daty
	- Ze jsem si vìdom toho, že takto uživatel mùže stahovat i cizí data, pokud bude zkoušet id v URL
	- Na produkci by se muselo udìlat øízení pøístupu dle pøihlášeného uživatele
	- Pokud by to byl public dotazník (bez pøihlašování), pak by místo ID vloženého záznamu bylo vhodné vracet celý objekt a parsovat na JSON
- Na stránce lze kliknout na odkaz, který uživatele vrátí na pøedchozí stránku a umožní vyplnìní nového formuláøe

**Obrazovka Failed**
- V pøípadì chyby se zobrazí informace o selhání s možností vyplnit formuláø znovu

Unit testy
- Využití xUnit frameworku pro pokrytí nìkterých metod testy

Závìr
- Bylo by vhodné doplnit další testy, napøíklad E2E testy pomocí nìkterého z frameworkù (napø. Selenium)
- Tìmito testy by se dalo testovat reálné použití formuláøe uživatelem

### Ing. Jindrich Netusil
- Linkedin: https://www.linkedin.com/in/jnetusil/
- Email: jindrich.netusil@seznam.cz
- Telefon: +420 777 788 786