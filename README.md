# TCP Multi-Thread Winform Chat
TCP Chat napisany od zera za pomoca WinForm, napisana wlasna biblioteka ktora ulepsza design chatu, do tego wszystkiego idzie wlasnorecznie napisany serwer
# Chat
Zwykly chat uzywany do komunikacji pomiedzy dwoma klientami
# Możliwości
- Wysyłka zwykłych tekstowych wiadomości
- Wysyłka wiadomości głosowych
- Wysyłka obrazków (.png, .bmp, .jpeg itd.)
- Wysyłka plików (.pdf, .docx, .tex, .mp3, .mp4, itd.)
![Screenshot_1](https://user-images.githubusercontent.com/19534189/90953705-354d1100-e46e-11ea-95bc-a228f98273a4.png)
# Server
Zwykly serwer ktory pozwala podlaczyc 2 klientow i sluzy do przeslania obrazkow oraz mailow od jednego klienta innemu. Pliki przesylane za pomoca protokolu TCP, wiec zadna czesc
pliku nie jest utracona po drodze.
![Screenshot_1](https://user-images.githubusercontent.com/19534189/89656017-3fe2a480-d8cb-11ea-802d-7364da77b315.png)
# Biblioteka ChatBubble
Source code tej biblioteki znajduje sie w branchu ChatLibrary, ta biblioteka realizuje chatbubbles dla wyslanego oraz dostanego maila oraz dla DateSelector ktory oddziela maile 
na gorze i pisze obecna date, oraz realizuje wyslane oraz dostane obrazki.
