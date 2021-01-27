# TCP Multi-Thread Winform Chat
TCP Chat napisany od zera za pomoca WinForm, napisana wlasna biblioteka ktora ulepsza design chatu, do tego wszystkiego idzie wlasnorecznie napisany serwer
# Chat
Zwykly chat uzywany do komunikacji pomiedzy dwoma klientami
# Możliwości
- Wysyłka zwykłych tekstowych wiadomości
- Wysyłka wiadomości głosowych
- Wysyłka obrazków (.png, .bmp, .jpeg itd.)
- Wysyłka plików (.pdf, .docx, .tex, .mp3, .mp4, itd.)
- Wysyłka live-video
#
![Screenshot_1](https://user-images.githubusercontent.com/19534189/104617267-87940600-568b-11eb-95b4-555ba63bb20e.png)
![Screenshot_2](https://user-images.githubusercontent.com/19534189/104617269-882c9c80-568b-11eb-93c2-84d6e1155d12.png)
# Server
Zwykly serwer ktory pozwala podlaczyc 2 klientow i sluzy do przeslania obrazkow oraz mailow od jednego klienta innemu. Pliki przesylane za pomoca protokolu TCP, wiec zadna czesc
pliku nie jest utracona po drodze.
![Screenshot_1](https://user-images.githubusercontent.com/19534189/89656017-3fe2a480-d8cb-11ea-802d-7364da77b315.png)
# Biblioteka ChatBubble
Source code tej biblioteki znajduje sie w branchu ChatLibrary, ta biblioteka realizuje chatbubbles dla wyslanego oraz dostanego maila oraz dla DateSelector ktory oddziela maile 
na gorze i pisze obecna date, oraz realizuje wyslane oraz dostane obrazki/wiadomości głosowe/pliki itd.
# Postępowanie po uruchomieniu projektu z GitHub
1. Klonujemy branch Master oraz ChatLibrary
2. Odtwarzamy solution dla ChatLibrary dodajemy do References MACTrackBarLib.dll
3. Kompilujemy ChatLibrary
4. W razie problemów ze skompilowaniem Chat+Server dodajemy do References skompilowaną biblioteke ChatLibrary bin/Debug/ChatLibrary.dll w **kroku 3** 
