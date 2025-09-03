# Pong-peli

Tämä on yksinkertainen Pong-peli, joka on toteutettu C# Windows Forms sovelluksena.
Tällä hetkellä voit pelata vain tietokonetta vastaan, mutta jatkokehityksessä on tarkoitus tehdä pelistä kahden pelaajan versio.

## Toiminnallisuus
- Pelaat vasemmalla puolella olevalla mailalla, tietokone oikealla.
- Nuolinäppäimillä voit liikuttaa mailaa ylös ja alas.
- Tietokone pelaa sinua vastaan liikuttamalla oikean puoleista mailaa automaattisesti.
- Ensimmäinen puoli joka saavuttaa 6 pistettä voittaa pelin.
- Yksi pallon missaus = 1 piste.

- ## Käyttöohjeet
- Lataa repository GitHubista.
- Avaa `Pongipeli.sln` Visual Studiossa.
- Käynnistä peli painamalla "Start" näppäintä Visual Studiossa.
- Peli alkaa välittömästi ja jatkuu kunnes ensimmäinen puoli saa 6 pistettä.
- Pelin päätyttyä saat viestin. Kun painat viestissä olevaa "OK" -nappia, alkaa peli alusta uudelleen.
- Voit myös ladata pelin suoraan tietokoneellesi Releases kohdasta "PongiPeliSetup.msi" -tiedoston GitHub profiilistani, jolloin et tarvitse Visual Studiota.

-  ## Koodin pääkohdat

-  Tämä osa koodia liittyy pallon, sekä tietokoneen nopeuteen.
-  Koodissa olevat kommentit selittävät koodia yksityiskohtaisemmin.
```
int ballXspeed = 4;
int ballYspeed = 4;
int speed = 2;
Random rand = new Random(); // Pallolle valitaan satunnainen nopeus
bool goDown, goUp;
int computer_speed_change = 50; // Kuinka usein tietokoneen nopeus vaihtelee
int playerScore = 0; // Pelaajan pistemäärä
int computerScore = 0; // Tietokoneen pistemäärä
int playerSpeed = 8;
int [] i = {5, 6, 8, 9}; // Tietokoneen nopeus valitaan näistä numeroista
int [] j = {10, 9, 8, 11, 12}; // Valitaan pallolle eri nopeus satunnaisesti (BallXspeed, ballYspeed)

```

# Pisteiden laskeminen

- Tämä osa koodia liittyy pisteiden laskemiseen.
- Koodissa olevat kommentit selittävät koodia yksityiskohtaisemmin.
```

      private void GameTimerEvent(object sender, EventArgs e)
      {
          ball.Top -= ballYspeed;
          ball.Left -= ballXspeed;

          this.Text = "Player Score: " + playerScore + " -- Computer Score: " + computerScore; // Näyttää pistetilanteen ja päivittää sitä

          if (ball.Top < 0 || ball.Bottom > this.ClientSize.Height)
          {
              ballYspeed = -ballYspeed;
          }
          if (ball.Left < -2) // Kun pallo on osunut vasempaan reunaan, eli pelaaja on missannut pallon niin resetoidaan pallo keskelle
          {
              ball.Left = 300; // Resetoidaan pallo keskelle
              ballXspeed = -ballXspeed;
              computerScore++; // Lisätään piste tietokoneelle
          }
          if (ball.Right > this.ClientSize.Width + 2)
          {
              ball.Left = 300; // Resetoidaan pallo keskelle 
              ballXspeed = -ballXspeed; // Kun pallo on osunut oikeaan reunaan, eli tietokone on missannut pallon
              playerScore++; // Lisätään piste pelaajalle
          }
```

## Pelaajan kontrollit
- Pelaajan kontrollit peliin. Ylos ja alas liikkuminen.

```

private void KeyIsDown(object sender, KeyEventArgs e)
    {
            if (e.KeyCode == Keys.Down)
        {
                goDown = true; // Jos pelaaja painaa nuoli alaspäin, menee paddle alaspäin
        }
        if (e.KeyCode == Keys.Up)
        {
                goUp = true; // Jos pelaaja painaa nuoli ylöspäin, menee paddle ylöspäin
        }
    }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
        }
```

## Pelin loppu
- Pelin loppuun liittyvää koodia.
- Ensimmäinen 6 pistettä saanut pelaaja voittaa.
- Peli keskeytetään, ja näytetään viesti jossa kerrotaan, loppuiko peli voittoon vai häviöön.
- Resetoidaan kaikki aloitusarvoihin ja aloitetaan peli alusta, kun pelaaja on painanut viestissä olevaa "Ok" -nappia.
```
 private void GameOver(string message) // Kun pelaaja voittaa tai häviää näytetään viesti, sekä palautetaan pallon nopeus alkuperäiseen nopeuteen
 {
     GameTimer.Stop();
     MessageBox.Show(message, "FINAL SCORE ");
     computerScore = 0; // Kun peli päättyy resetoidaan pisteet tietokoneelta
     playerScore = 0; // Sama myös pelaajalle
     ballXspeed = ballYspeed = 4; // Resetoidaan pallon nopeus takaisin hitaampaan alkunopeuteen
     computer_speed_change = 50;
     GameTimer.Start();
 }
```
## Vuokaavio
<img width="656" height="799" alt="vuokaaviopong" src="https://github.com/user-attachments/assets/d7194242-1639-4b35-b160-2899f2a2a15d" />



## Pelin Yleiskuvaa
  <img width="899" height="552" alt="pong yleiskuva" src="https://github.com/user-attachments/assets/190df8d9-5b55-4b6e-a327-e6211c5c083b" />

## Pelaaja häviää
<img width="898" height="557" alt="häviö" src="https://github.com/user-attachments/assets/6bbeac2e-747c-48c7-9f04-74cd0135b757" />

## Pelaaja voittaa
<img width="891" height="551" alt="voitto" src="https://github.com/user-attachments/assets/6fd4e883-24cd-486f-8894-0ba3e605be18" />

## Video
https://github.com/user-attachments/assets/f1fbed40-5c57-4288-b509-40badf89b44d

"# PongPeli" 
