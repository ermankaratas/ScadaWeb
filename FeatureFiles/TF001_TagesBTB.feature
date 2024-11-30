Feature: Tages-Betriebstagebuch functionality

Background:
    Given Navigieren Sie zu scada.web
    When Sie geben Benutzernamen und Passwort ein und klicken auf die Anmelden-Taste
    Then Der Benutzer sollte sich  erfolgreich anmelden

Scenario: Neues Tages-Betriebstagebuch erstellen
    Given Navigieren Sie zum Menu "Einstellungen"
    When Der Benutzer klickt auf die Option "Betriebstagebuch konfigurieren"
    Then Der Benutzer sieht das Menü "Neues Betriebstagebuch"
    When Der Benutzer klickt auf die Option "Neues Betriebstagebuch"
    When Der Benutzer klickt auf die Option "Tages-Betriebstagebuch"
    Then Der Benutzer gibt im Pop-Up Fenster "TEST-TAG-AUTO-6" an.
    Then Der Benutzer klickt auf die Tastatur "OK"
    Then Das neue Tages-Betriebstagebuch mit dem angegebenen Namen erstellt wurde
