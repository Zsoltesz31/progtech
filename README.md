# Progtech beadandó
## Dizájn dokumentum

A beadandó feladatom témája egy gyümölcs feldolgozó raktár egyszerű szimulációja. A raktár alapvető funkciójait valósítottam meg, mint például: gyümölcs vásárlása, gyümölcs leszállítása a raktár részére. Módosíthatjuk a raktárban szereplő gyümölcsök adatait, azaz az árukat és a származási helyüket (szüret helyét). Vásárlás során a raktár kapacitásától függően, leértékelést kap a vásárló. A raktár minél inkább telített annál nagyobb leértékelést kap a vásárló. Ezt arra alapozom, hogy a gyümölcs nem állhat túl sokáig egy adott raktárban, hanem minél hamarabb feldolgozásra kell, hogy kerüljön. Ez alapján a raktárnak meg kell szabadulnia a gyümölcsöktől így, ha az nagyon telített akkor, ha pénzveszteség árán is, de tovább kell, hogy adja a gyümölcsöket. A leértékelés annak függvényében nő minnél több gyümölcs van raktáron. A felhasználó betekintést nyerhet a raktár aktuális állapotára, azaz, milyen gyümölcsből hány kg áll rendelkezésre. 
# Adatmodellek:
- Fruit: cost:int, harvestingplace:string 			A gyümölcsök ősösztálya
- Cherry, Peach, SourCherry 					A Fruit osztály alosztályai
- BergeronPeach, LindaCherry, ErdiSourCherry	A gyümölcsök alfajai (dekorátor tervezési minta)
 
A szimulációs feladatokat, azaz a raktár működésést a StorageActions nevű osztályban implementált függvények végzik. A felhasználó álltal adott input alapján lépünk az egyik módba a 4 közül (vásárlás, szállítás, listázás, módosítás). A gyümölcsök példányosítását a FruitFactory osztály végzi (Factory tervezési minta). A projektben egy raktár vesz részt így azt a Singleton tervezési minta segítségével implementáltam. 
 
# Alkalmazott tervezési minták:

# Factory:
A factory tervezési mintát a számos példányosítás kiváltása miatt implementáltam. A projektben több helyen is létrekell hoznom gyümölcs példányokat vagy adott gyümölcsök alfajait. Amikor a raktárba áru érkezik vagy éppen amikor alapadatokkal feltöltöm a raktárat(gyümölcsökkel) a FruitFactory makeFruit() metódusát hívom meg. A makeFruit() metódus hajtja végre a példányosítást a felhasználó inputja alapján, itt kerül eldöntésre, hogy milyen gyümölcs példányt hozzon létre a Factory. A paraméterezés alapján ha adunk meg alfajt akkor a FruitFactory makeFruitSubspiece() metódusa hívódik meg a makeFruit() metóduson keresztül és egy speciális gyümölcs fajta kerül példányosításra (bergeron, linda, érdi). Természetesen ha csak egy gyümölcs nevet adunk meg akkor egy alap gyümölcs példány kerül példányosításra(barack, meggy vagy cseresznye).

# Singleton:
A projektemben a singleton tervezési mintát a raktár azaz a Storage osztály implementálásánal alkalmaztam. Mivel jelenleg egy raktárunk van így tökéletes alany a Storage osztályunk a tervezési minta alkalamazására. A StorageActions osztály konstruktorában hívjuk meg a Storage Storage.Instance property-jét, ami csak get mezővel rendelkezik és set-el nem. Így a privát konstruktornak köszönhetően csak a Instance propertyn keresztül ellenőrízhetjük, hogy van-e már példányunk a Storage-ból, ha még nincs akkor visszakapjuk a propertyn keresztül a példányunkat a raktárból.

# Decorator:
Ahhoz, hogy a különböző gyümölcsök alfajait implementáljam fontos volt, hogy a Peach, Cherry, SourCherry osztályok viselkedése ne változzon, azok változtatása nélkül tudjak implementálni alfajtákat az adott gyümölcsökhöz. Jelenleg a dészítő a Peach, Cherry, SourCherry osztály Cost és HarvestingPlace property-jeit módosítja. Az ár drágább lesz egy adott összeggel, valamint a szüret helyéhez megadja a fasort, hogy melyik fasorból rázták vagy szedték a gyümölcsöt. Ezek alapján megtudjuk különbeztetni a Peach és a BergeronPeach osztályokat még ha az ősük közös is, de mégis különböznek egymástól anélkül, hogy hatással lennének az azonos osztályból származó többi objektumra.

# Observer:
A raktárban történő módosítások során, azaz, ha megváltozik egy gyümölcs ára vagy szürethelye arról valamilyen módon értesítenünk kell a rendszert, hogy ne csak egy gyümölcs árát változtassa meg hanem az összes olyan gyümölcsnek melynek módosítottuk valamilyen tulajdonságát. Ennek megvalósítására szükségünk van úgymond egy figyelőre és egy alanyra, aki szól majd a figyelő részére, ha valami változás történt. Ezt a figyelőt és alanyt az Observer tervezési minta segítségével valósítottam meg. Az alanyt és az observert mint interface hoztam létre. Az alany metódusait a StorageActions osztály implementálja, így amikor a módosítási opciót választja a felhasználó és módosítja egy adott gyümölcs adatait akkor az alany értesíteni fogja az observert a változtatásokról. Az observer ezután az updateProperties() metódusán keresztül elvégzi a módosításokat a Fruit osztályon ár és szüretelési hely módosítása. 

# Tesztelés:
A unit tesztelést a VisualStudio beépített Unit Test Project segítségével végeztem. Ahhoz, hogy a teszt metódusokat implementálni tudjam először is a Unit Test Projectet a jelenlegi projekttel egy könyvtárba kell létrehozni és Test project függésegi közé fel kell venni a tesztelni kívánt projektet. Ezután a teszt projektben már elérjük a tesztelni kívánt projektünk névterét és elkezdhetjük a tesztelést.
A Storage osztály metódusait teszteltem, hiszen a fő metódusuk, amelyek irányítják a raktárat itt helyezkednek el. A tesztek sikerességét az Assert nevű metódus vizsgálja. Az Assert metódus vizsgálhatja például, hogy két objektum megegyezik-e, egy adott objektum null-e, van-e különbség két metódus között stb.
# Storage osztály tesztelt metódusai:
- addFruit(): Sikeres-e a hozzáadás, a gyümölcs lista elemszáma nőtt-e
- deleteFruit(): Sikeres-e a példány törlése, változik-e a gyümölcsök listája törlés után
- getSellableFruits(): Az eladható gyümölcsök kilistázása nem-e null értékkel tér vissza
- getDiscounts(): Változik-e a rendelés ára ha jár leárazás
- getFruitByType(): Annak vizsgálata, hogy a lista tartalmaz-e egy adott gyümölcs típusú példányt 
