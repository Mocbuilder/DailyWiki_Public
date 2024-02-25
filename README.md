# DailyWiki
This is the public source code for my DailyWiki project. It is a program that randomly fetches a wikipedia articcle from the wikimediaAPI. 
All of this is wrapped in a simple ASP.Net webapp to display and log all articles, so it is technically ready to deploy to a server.

## Webscrapper
The webapp and the webscrapper are two relatively seperated projects, with the webscrapper beeing a console application in its most bare state.
The webscrapper has basic saving and displaying functions to work with the extracted articles.

It works in the way that it requests a random article from the wikimediaAPI and then scrapes the webpage for the neccesary information, cleans the scrapped text (atleast a bit) and gives it to the webapp.

## Webapp
The webapp is only a simple interface that has basic interaction features with the webscrapper. It displays the article provided by the webscrapper and also logs all previously displayed articels (of the currently running instance, so only as long as the instance runs).
