 # <center>**Entity Framework Core**</center>

# <center>**Concurrency øvelser**</center>







##  **Klargøring**

###   Demo projekt

Hent (ItsLearning) og ud pak ”CoreEfConcurrency_Init.zip”

### Tilpas connectionstring

Gå ind i ”BloggingContext.cs” og tilpas connectionString.

### Dan databasen

Brug ”migration” til at danne databasen.

 

## **Tilføj concurrency tokens til tabellerne**

Se evt. her: https://docs.microsoft.com/en-us/ef/core/modeling/concurrency

Brug row version.

 

## **Test løsningen**

Gør følgende:

1. Opdatering i C#
	a. Skriv kode hvor to context’s opdaterer samme element i databasen.
	b. Tjek at der kommer concurrency fejl
2. Blandet opdatering
	a. Skriv kode hvor en context opdaterer et element i databasen
	b. Kør koden indtil SaveChanges.
	c. I Sql manager ændres samme element.
	d. Tjek at der kommer concurrency fejl

 

##  