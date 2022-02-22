# Órai feladat – Interfész

## Bevezetés

A lenti leírás egy egyszerű számkitalálós játék elkészítését mutatja be. A játék célja, hogy egy
megadott intervallumon belüli véletlenül kiválasztott számot kell eltalálni. Interfészek segítségével
különböző stratégiákat fogunk ehhez készíteni (véletlen tippelés, bejárás, logaritmikus keresés,
emberi játékos, stb.), majd pedig ezekből statisztikákat készíteni, hogy melyik módszer mennyire volt
eredményes.

## Feladatok

### Játékot vezérlő osztály és alapvető interfészei

Készíts egy **IJatekos** interfészt, amely az alábbi metódusokat írja elő:

- **Nyert()** – akkor kell majd meghívni, ha nyert a játékos (nincs visszatérési értéke)
- **Veszitett()** – akkor kell majd meghívni, ha veszített a játékos (nincs visszatérési értéke)

Készíts egy **ITippelo** interfészt, amely kiterjeszti az **IJatekos** - t az alábbiakkal:

- **JatekIndul(alsoHatar, felsoHatar)** – a játék indulásakor kell meghívni, megadva az eltalálni
    kívánt szám minimális és maximális értékét (nincs visszatérési értéke)
- **KovetkezoTipp()** – egy egész számot visszaadó metódus. Ezen keresztül fogja a játékos
    megadni a következő tippet

Készíts egy **SzamKitalaloJatek** nevű osztályt az alábbiak szerint:

- **MAX_VERSENYZO** – versenyzők maximális száma (konstans érték, legyen 5)
- **versenyzok** – egy _MAX_VERSENYO_ méretű, _ITippelo_ - t megvalósító elemeket tartalmazó tömb
- **versenyzoN** – az aktuálisan a tömbben lévő versenyzők száma
- **VersenyzoFelvetele(ITippelo)** – egy versenyzőt felvesz a tömbbe
- **alsoHatar, felsoHatar** – két egész szám, amelyek a konstruktoron keresztül kapnak értéket. A
    játék célja az lesz, hogy ki kell találni egy számot a két határ között
- **VersenyIndul()** – a hívást követően dob egy véletlen számot _alsoHatar_ és _felsoHatar_ között,
    ezt tárolja el egy **cel** nevű mezőben. Ezt követően hívja meg az összes felvett játékos
    _JatekIndul_ metódusát
- **MindenkiTippel()** – ez fog végrehajtani egy kört az alábbiak szerint: egymást követően
    minden játékosnak meghívja a _KovetkezoTipp()_ metódusát. Amennyiben sikerült eltalálni a
    _cel_ értéket, akkor hívjuk meg a játékos _Nyert()_ metódusát. Ha többen is eltalálták a számot
    egy körön belül, akkor mindannyian nyertek. Amennyiben legalább egy játékos nyert, akkor a
    kör végén (vagy közben) minden rossz tippet megadó játékosnak meg kell hívni a _Veszitett()_
    metódusát. A _MindenkiTippel_ metódus visszatérési értéke legyen igaz akkor, ha volt nyertes
    és hamis, ha senki se találta el a számot.
- **Jatek()** – ez a metódus egy teljes játékot játszik le. Hívja meg először a _VersenyIndul()_
    metódust, majd pedig egy ciklusban addig hívja a _MindenkiTippel()_ metódust, amíg az nem ad
    vissza igazat (tehát amíg valaki(k) nem nyert(ek)).


```
Vegyük észre, hogy sikerült elkészíteni a játék teljes logikáját és működését anélkül, hogy akár egyetlen játékost
is készítettünk volna. Az interfészek csak azt határozzák meg, hogy ezeknek a játékosoknak milyen funkcióik
lesznek majd, de hogy ezt hogy valósítják meg, azt nem.
```
### Néhány egyszerűbb játékstratégia megvalósítása

Készíts egy **GepiJatekos** nevű absztrakt osztályt, amely megvalósítja az _ITippelo_ interfészt. Ez majd a
leendő gépi stratégiák őse lesz:

- **alsoHatar** , **felsoHatar** – két egész szám, amelyek között majd tippelnie kell
- **JatekIndul(alsoHatar, felsoHatar)** – beállítja a fenti két értéket
- **nyertDB** , **veszitettDB** – két egész szám, amelyek tárolják az eredményeket
- **Nyert()** – növeli a _nyertDB_ értékét
- **Veszitett()** – növeli a _veszitettDB_ értékét
- **KovetkezoTipp()** – az interfész miatt meg kellene valósítani, de ezen a szinten még nem
    tudjuk, ezért legyen absztrakt metódus

Készíts egy **VeletlenTippelo** nevű osztályt, ami a _GepiJatekos_ leszármazottja:

- **KovetkezoTipp()** – valósítsuk meg ezt a metódust úgy, hogy mindig egy véletlenszámot ad
    vissza _alsoHatar_ és _felsoHatar_ között

Készíts egy **BejaroTippelo** nevű osztályt, ami a _GepiJatekos_ leszármazottja:

- **aktualis** – egy egész szám, ami a következő tippet mutatja mindig
- **JatekIndul(alsoHatar, felsoHatar)** – hívja meg az ős metódusát, majd állítsa be az _aktualis_
    mező értékét _alsoHatar_ - ra
- **KovetkezoTipp()** – visszaadja az _aktualis_ értékét, majd annak értékét növeli 1-gyel

Teszt1: Most már ki tudjuk próbálni a rendszert. Hozz létre egy _SzamKitalaloJatek_ objektumot és egy-
egy _VeletlenTippelo_ és _BejaroTippelo_ - t. Ezeket kapcsold össze és játssz le egy játékot. Hogy lássuk mi
történik, ideiglenesen célszerű a képernyőre kiírni a folyamat részeredményeit. Például egy 10- 20
közötti játékot indítva egy lehetséges kimenet:

```
VersenyIndul
cel:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
```
```
Mivel a Random objektum inicializációjakor a gépi időt veszi alapul, ezért előfordulhat, hogy az egymás után
gyorsan létrehozott Random objektumok mindig ugyanazokat a pszeudovéletlen számokat adják. Ilyenkor
```

```
célszerű lehet a programon belül egyetlen darab Random objektumot használni, pl. egy erre a célra létrehozott
statikus osztályban.
```
### Hatékonyabb játékstratégia megvalósítása

Egészítsük ki úgy a játékot, hogy az okosabb játékosokat is támogassa annyival, hogy megmondjuk
nekik, hogy a tippnél a keresett szám kisebb vagy nagyobb.

Ennek érdekében készítsünk egy **IOkosTippelo** nevű interfészt, az kiterjeszti az _ITippelo_ interfészt az
alábbiak szerint:

- **Kisebb()** – ezt a metódust hívjuk akkor, ha a tippnél kisebb a keresett szám
- **Nagyobb()** – ezt a metódust hívjuk akkor, ha a tippnél nagyobb a keresett szám

A fenti működéshez módosítanunk kell a _SzamKitalaloJatek_ osztályt is:

- **MindenkiTippel()** – módosítsuk úgy a metódust, hogy hibás tipp esetén ellenőrizzük, hogy az
    aktuális játékos megvalósítja-e az _IOkosTippelo_ interfészt. És ha igen, akkor a hibának
    megfelelően hívjuk meg a _Kisebb_ vagy _Nagyobb_ metódusát (kasztolni kell majd).

Készítsünk egy **LogaritmikusKereso** osztályt, ami az _IGepiJatekos_ leszármazottja, de ezen felül
megvalósítja az _IOkosTippelo_ interfészt is.

- **KovetkezoTipp()** – felülírja ennek a metódusnak a működését úgy, hogy mindig az _alsoHatar_
    és _felsoHatar_ közötti középső értéket adja vissza
- **Kisebb()** – mivel tudjuk, hogy ez akkor hívódik meg, amikor az előző tippnél kisebb a keresett
    szám, ezért a _felsoHatart_ ennek megfelelően kisebbre állítja
- **Nagyobb()** – mivel tudjuk, hogy ez akkor hívódik meg, amikor az előző tippnél nagyobb a
    keresett szám, ezért az _alsoHatar_ értékét ennek megfelelően nagyobbra állítja

Teszt2: Egy _LogaritmikusKereso_ játékossal kiegészítve a játékot már hasonló eredményt várhatunk:

```
VersenyIndul
cel:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
Interfesz.LogaritmikusKereso tippje:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
Interfesz.LogaritmikusKereso tippje:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
Interfesz.LogaritmikusKereso tippje:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
Interfesz.LogaritmikusKereso tippje:
MindenkiTippel
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
Interfesz.LogaritmikusKereso tippje:
```
### Emberi játékos megvalósítása

A fentiek alapján már egyszerűen készíthetünk egy emberi játékost is. Feltételezzük, hogy okos lesz a
játékosunk, ezért készítsünk egy **EmberiJatekos** osztályt, ami megvalósítja az _IOkosTippelo_ - t. Ez csak
a bemenetet/kimenetet fogja biztosítani a játékos felé, ezért nincs is saját mezője. Az interfész által
megadott metódusokat az alábbiak szerint valósítsuk meg:


- **JatekIndul(alsoHatar, felsoHatar)** – írja ki a képernyőre, hogy kezdődik a játék megadott
    határokkal
- **Kisebb()** – írja ki a képernyőre, hogy „az előző tippnél kisebb a keresett szám”
- **Nagyobb()** – írja ki a képernyőre, hogy „az előző tippnél nagyobb a keresett szám”
- **KovetkezoTipp()** – írja ki a képernyőre, hogy „add meg a következő tippet”. Kérjen be egy
    számot, és ez legyen a függvény visszatérési értéke
- **Nyert()** – írja ki a képernyőre, hogy „nyertél”
- **Veszitett()** – írja ki a képernyőre, hogy „veszítettél”

Teszt3: egy _EmberiJatekos_ felvétele után már mi is játszhatunk (egy csillag jel került az _EmberiJatekos_
üzenetei elé, hogy megkülönböztethetőek legyenek a napló soroktól, kék színnel jelöltem azt, amit én
írtam be a konzolra):

```
VersenyIndul.
cel:
*Jatek indul az alábbi határok között: [10,50]
MindenkiTippel
*Add meg a következő tippet: 19
Interfesz.EmberiJatekos tippje:
*Az előző tippnél nagyobb a keresett szám
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
Interfesz.LogaritmikusKereso tippje:
MindenkiTippel
*Add meg a következő tippet: 26
Interfesz.EmberiJatekos tippje:
*Az előző tippnél nagyobb a keresett szám
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
Interfesz.LogaritmikusKereso tippje:
MindenkiTippel
*Add meg a következő tippet: 29
Interfesz.EmberiJatekos tippje:
*Az előző tippnél nagyobb a keresett szám
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
Interfesz.LogaritmikusKereso tippje:
MindenkiTippel
*Add meg a következő tippet: 31
Interfesz.EmberiJatekos tippje:
*Az előző tippnél nagyobb a keresett szám
Interfesz.VeletlenTippelo tippje:
Interfesz.BejaroTippelo tippje:
Interfesz.LogaritmikusKereso tippje:
*Veszítettél!
```
### Statisztikák készítése

Szeretnénk összehasonlítani az egyes stratégiák hatékonyságát, ehhez készítsünk egy
**IStatisztikatSzolgaltat** nevű interfészt az alábbi csak olvasható egész tulajdonságokkal:

- **HanyszorNyert** – egy számot ad majd vissza, hogy hányszor nyert az adott objektum
- **HanyszorVesztett** – egy számot ad majd vissza, hogy hányszor veszített az adott objektum

Egészítsük ki a _GepiJatekos_ osztályt úgy, hogy megvalósítja ezt az interfészt is. Az ehhez szükséges
adatokat szerencsére már tároljuk, ezért csak két tulajdonságot kell létrehozni:

- **HanyszorNyert** – az interfészben megadott tulajdonság adja vissza a _nyertDB_ értékét
- **HanyszorVeszitett** – az interfészben megadott tulajdonság adja vissza a _veszitettDB_ értékét

Egészítsük ki a _SzamKitalaloJatek_ osztályt az alábbiak szerint:


- **Statisztika(korokSzama)** – a metódus a paraméterként megadott számú játékot játssza le
    egymást követően (a _Jatek_ metódust kell csak meghívni többször). Ezt követően nézze végig a
    versenyzőket, és ha valamelyik megvalósítja az _IStatisztikatSzoglaltat_ interfészt, akkor annak
    adatait írja ki a képernyőre.

Teszt4: emberi játékost ne használjuk, csak a három gépi stratégiát. A _Statisztika_ eljárást futtatva
1000 játékra hasonlót láthatunk (ahogy az várható, a logaritmikus kereső nyeri a legtöbbet):

_0. jatekos (Interfesz.VeletlenTippelo), NY:88 V:
1. jatekos (Interfesz.BejaroTippelo), NY:97 V:
2. jatekos (Interfesz.LogaritmikusKereso), NY:836 V:_

```
Érdemes megnézni, hogy ha nincs logaritmikus kereső, akkor a bejáró fog nyerni, mivel hasonlóak az esélyei
mint a véletlen tippelőnek, csak kétszer nem próbálkozik ugyanazzal a számmal
```
### Kaszinó mód beépítése

Egészítsük ki a játékot azzal, hogy legyen egy maximális tipp szám, ami alatt el kell találni a számot.
Ha ez alatt senki se találta el, akkor a „kaszinó” nyert. Ehhez készítsünk egy **SzamKitalaloJatekKaszino**
nevű osztályt, ami a _SzamKitalaloJatek_ leszármazottja és azt kiegészíti az alábbiakkal:

- **kaszinoNyert, kaszinoVeszitett** – egész számok, amelyek tartalmazzák, hogy hányszor nyert,
    illetve veszített a kaszinó
- **korokSzama** – egész számot tartalmazó mező, ami a maximális körök számát tartalmazza
- **konstruktor** – az _alsoHatar_ és _felsoHatar_ adatok mellett itt lehessen megadni a _korokSzama_
    értékét is. Az első két értéket adja tovább az ős konstruktorának
- **Jatek()** – módosítsuk úgy a játékot, hogy a _VersenyIndul_ hívása utáni ciklusban maximum
    _korokSzama_ - szor hívja meg a _MindenkiTippel_ metódust (vagy persze addig, amíg valaki
    nyert). Ha a ciklusból azért léptünk ki, mert valamelyik játékos eltalálta a számot, akkor
    növeljük a _kaszinoVeszitett_ értékét, egyébként pedig növeljük a _kaszinoNyert_ értékét
- az osztály megvalósítja az _IStatisztikatSzolgaltat_ interfészt is, ahol a _HanyszorNyert_ metódus
    a _kaszinoNyert_ értékét, a _HanyszorVeszitett_ metódus pedig a _kaszinoVeszitett_ értékét adja
    vissza
- **Statisztika(korokSzama)** : hívja meg az ős azonos nevű metódusát, majd annak lefutását
    követően írja ki a képernyőre a kaszinó nyerési adatait is

```
Vegyük észre, hogy a SzamKitalaloJatekKaszino és a gépi játékosok is megvalósítják a IStatisztikatSzolgaltat
interfészt. Pedig egymástól meglehetősen távoli osztályok közös ős nélkül, de egy bizonyos szempont szerint
hasonló működést várunk tőlük (számolják az eredményeket). És az interfészen keresztül közösen kezelhetők.
```
Teszt5: készítsünk egy _SzamKitalaloJatekKaszino_ objektumot 1-100 közötti határokkal és 6 - os kör
limittel. Így hasonló eredményt kaphatunk (7 lépésnél a logaritmikus keresés már mindig meg fogja
találni az eredményt időben):

_0. jatekos (Interfesz.VeletlenTippelo), NY:54 V:
1. jatekos (Interfesz.BejaroTippelo), NY:51 V:
2. jatekos (Interfesz.LogaritmikusKereso), NY:565 V:
Kaszino, NY:337 V:_

## Opcionális kiegészíti lehetőségek

### Naplózás

Ha valakit (jogosan) zavar, hogy az üzleti logikát megvalósító osztályokból írunk a konzolra, akkor
célszerű ezt is egy interfésszel megvalósítani. Készítsünk egy **INaploz** interfészt, aminek egy


**naplobaIr(szöveg)** metódusa van. A _SzamKitalaloJatek_ - nak legyen egy ilyen típusú mezője, és a
konzolra írás sorokat mindenhol cseréljük ki arra, hogy ha van ebben a mezőben bármi, akkor annak
meghívjuk a _naplobaIr_ metódusát, ha nincs, akkor pedig nem naplózunk.

Ezt követően készíthetünk különböző _INaploz_ megvalósításokat, pl. olyat ami a konzolra írja az
üzeneteket, de olyat is, ami fájlba.


