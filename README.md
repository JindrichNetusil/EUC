# EUC
## Online vstupn� dotazn�k
Pou�it� technologie
- .NET 9
- Entity Framework Core
- Automapper
- MSSQL
- Blazor
- MudBlazor UI
- xUnit

### N�vod na rozb�hnut�
- Aktualizovat Visual Studio a nainstalovat .NET 9
- Rozb�hnout localdb, nebo v appsettings.json zm�nit connection string na jinou DB
- Spustit na MSSQL [master] datab�zi skript ze slo�ky EUC_DB k vygenerov�n� struktury DB
	- Alternativn� pouze zalo�it DB [euc] a spustit migraci p�es EF Core
- Zkontrolovat sta�en� v�ech NuGet packages a ostatn�ch dependencies projektu
- Buildnout a spustit projekt ze slo�ky EUC

### Diskuse k zad�n�
Co bylo p�id�no, nebo upraveno oproti zad�n� a pro�?

**Obrazovka Dotazn�k**
- Jazyk
	- Jazyk syst�mu je ��zen pomoc� API controlleru, kter� nastavuje do cookie culture
	- Culture pot� v cel�m syst�mu ��d� p�eklady, form�ty datum� a podobn�
	- P�eklady jsou �e�eny pomoc� Resources ve slo�ce Locales
- Jm�no a p��jmen�
	- Bylo oproti zad�n� rozd�leno na dv� pole (datab�zov� normalizace)
- Rodn� ��slo
	- P�id�na podpora pro nov� zm�ny R� v roce 2024, kter� v ur�it�ch p��padech umo��uj� p�id�vat do sekce m�s�ce R� +70 pro �eny a +20 pro mu�e
	- P�id�ny validace:
		- Nevalidn� znaky
		- �patn� pozice lom�tka
		- Nespr�vn� po�et ��slic
		- Spr�vnost datumov� slo�ky
		- �e�en� p�esto neobsahuje 100% valid�tor R�, kter� by bylo nutno na produk�n� verzi d�kladn� odladit
- Datum narozen�
	- P�id�ny validace a omezen�:
		- Nelze vybrat datum narozen� vy��� ne� je aktu�ln� den
		- Nen� mo�n� z datepickeru vybrat datum narozen�, pokud je vypln�no R�
		- Pokud u�ivatel zad� R�, kter� obsahuje datum vy��� ne� aktu�ln� den, toto datum se nep�edvypln�
- Pohlav�
	- P�id�ny funkce:
		- P�edvypl�uje se dle zadan�ho R�, ale nech�v� u�ivateli prostor zvolit jin�, nebo "Ostatn�"
- Email
	- P�id�ny validace:
		- Detekce mezer v adrese
		- Validce chyb�j�c�ho "@" znaku
		- Validce �patn�ho form�tu adresy
		- Validce probl�m� v lok�ln� ��sti adresy
		- Validce probl�m� v dom�nov� ��sti adresy
- St�tn� p��slu�nost
	- Pro zjednodu�en� p�id�ny pouze 3 (�esk�, slovensk�, ostatn�)
- Souhlas s GDPR
	- Vyzkou�el jsem 2 varianty
		- Vyu�it� odkazu (a href s _blank targetem)
		- Druhou variantu - p�es API controller vrac�m soubor
	- Rozhodl jsem se pro API controller, proto�e je pak mo�n� l�pe ��dit p��stup
	- API controller vyu��v�m i d�le ke sta�en� JSONu (na produkci by bylo nutn� ��dit p��stup)
- Tla��tko odeslat
	- Validuje znovu cel� form klientsky
	- Pokud validace na klientovi sel�e, nedoch�z� k vol�n� servicy
	- Pokud validace projde, odes�laj� se data na servicu
	- V service se validuj� data je�t� jednou p�ed ulo�en�m do datab�ze
	- V p��pad� �sp�n�ho ulo�en� (vr�t� se ID ulo�en�ho z�znamu) je u�ivatel p�esunut na obrazovku Success, kde si m��e st�hnout JSON nebo vyplnit dal�� formul��
	- V p��pad� chyby vrac� service jako result null a zobraz� se u�ivateli obrazovka Failed, kde se dozv�, �e operace ulo�en� selhala a m��e zkusit vyplnit formul�� znovu

**Obrazovka Success**
- Po odesl�n� formul��e a kladn�ho sc�n��e se zobraz� pod�kov�n� za odesl�n� formul��e
- Na str�nce lze st�hnout JSON s vypln�n�mi daty
	- Ze jsem si v�dom toho, �e takto u�ivatel m��e stahovat i ciz� data, pokud bude zkou�et id v URL
	- Na produkci by se muselo ud�lat ��zen� p��stupu dle p�ihl�en�ho u�ivatele
	- Pokud by to byl public dotazn�k (bez p�ihla�ov�n�), pak by m�sto ID vlo�en�ho z�znamu bylo vhodn� vracet cel� objekt a parsovat na JSON
- Na str�nce lze kliknout na odkaz, kter� u�ivatele vr�t� na p�edchoz� str�nku a umo�n� vypln�n� nov�ho formul��e

**Obrazovka Failed**
- V p��pad� chyby se zobraz� informace o selh�n� s mo�nost� vyplnit formul�� znovu

Unit testy
- Vyu�it� xUnit frameworku pro pokryt� n�kter�ch metod testy

Z�v�r
- Bylo by vhodn� doplnit dal�� testy, nap��klad E2E testy pomoc� n�kter�ho z framework� (nap�. Selenium)
- T�mito testy by se dalo testovat re�ln� pou�it� formul��e u�ivatelem

### Ing. Jindrich Netusil
- Linkedin: https://www.linkedin.com/in/jnetusil/
- Email: jindrich.netusil@seznam.cz
- Telefon: +420 777 788 786