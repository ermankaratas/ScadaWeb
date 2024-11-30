Feature: Anmeldung functionality

Scenario: Anmeldung mit gültigem Benutzernamen und Passwort
    Given Navigieren Sie zu scada.web
    When Sie geben Benutzernamen und Passwort ein und klicken auf die Anmelden-Taste
    Then Der Benutzer sollte sich  erfolgreich anmelden
