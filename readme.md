![Logo](/Fisiere/Logo.png)

# Despre proiect

InfoFirma este un program de administrare a datelor unei firme.

Aplicația este construită folosind .NET Framework în limbajul C#, iar pentru baza de date este utilizat Microsoft Access (Fișier `.MDB`).

# Instalare și configurare

Pentru a executa proiectul trebuie instalat un runtime pentru Access Database. Fișierul se găsește la secțiunea Releases.

Deasemenea în directorul unde este prezent executabilul proiectului trebuie să fie amplasat fișierul bazei de date, cu numele `BazaDate.mdb`. Un fișier eșanțion pentru baza de date este inclus la secțiunea Releases.

# Design

Design-ul aplicației a fost realizat în special pentru sistemele de operare Windows 10 și Windows 11, cu un title bar custom.

Pentru aceasta, a fost dezactivat title bar-ul implicit din Windows folosind proprietățile Form-ului și am utilizat metode custom pentru definirea stilului toolbar-ului și pentru a permite mutarea ferestrei. (Vezi [MyFormStyles.cs](/InfoFirma/MyFormStyles.cs)).

![Formular de login](/Fisiere/Screenshot/Login.png)

_Formularul de login_

# Fereastra principală

În partea de sus a ferestrei este prezent un meniu (butonul Opțiuni) și o listă de tab-uri pentru a accesa diferite vizualizări ale bazei de date.

_Tab-ul Angajați_
![Tab-ul angajați](/Fisiere/Screenshot/Angajati.png)

_Tab-ul Proiecte_
![Tab-ul proiecte](/Fisiere/Screenshot/Proiecte.png)

Acest tab prezintă o implementare a unui control DatePicker în interiorul unui control DataGridView realizată de mine: [vezi cod](/InfoFirma/MainForm.cs#130).

_Tab-ul Clienți_
![Tab-ul clienti](/Fisiere/Screenshot/Clienti.png)

_Tab-ul Departamente_
![Tab-ul departamente](/Fisiere/Screenshot/Departamente.png)

_Tab-ul Utilizatori_
![Tab-ul utilizatori](/Fisiere/Screenshot/Utilizatori.png)

Utilizatorii pot fi asociați unui angajat.

# Structura bazei de date

![Structura bazei de date](/Fisiere/Screenshot/Bazadate.png)
