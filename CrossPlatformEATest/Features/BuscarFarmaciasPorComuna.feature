Feature: Consultar Famrmacias de turno 

Feature: Consultar Famrmacias de turno 
Escenario: como un usuario que necesita saber las farmacias de turno 


Dado que quiero saber las farmacias de turno ingreso a la aplicación "URL"
Cuando la página "nombre de página" carga 
Entonces Se despliegan las comunas y nombres de las farmacias
Cuando yo selecciono una comuna y el nombre de una farmacia
Entonces se muestran las farmacias de turno de esa marca y comuna 

Criterios de aceptación 
1.- La consulta debe visualizar los siguientes campos: 
	a. Dirección 
	b. Telefono
	c. Latitud 
	d. Longitud 

2.- Arquitectura debe ser una api rest full 
3.- El código debe estar en repositorio público 
4.- Debe contener pruebas unitarias automáticas.
5.- Deben Realizarse pruebas funcionales de sistema automatizadas 
6.- Cuando se carga la página debe permitir seleccionar comuna y nombre de farmacia, no puede realizar consultas si no recibe ambos parámetros 
7.- CUando se carga la página deben cargarse las comunas y los nombre de farmacia 

Scenario Outline: como un usuario que necesita saber las farmacias de turno 
Given que quiero saber las farmacias de turno ingreso a la aplicación
When la página "Buscar Farmacias" carga 
Then Se despliegan las comunas y nombres de las farmacias
When yo selecciono una comuna '<Comuna>' y el nombre de una farmacia '<Farmacia>' y presiono el boton "Buscar"
Then se muestran las farmacias '<Farmacia>' de turno de esa marca y comuna '<Comuna>' y validar la siguiente data '<Local_id>'

Examples: 
| Comuna     | Farmacia   | Local_id            |
| CERRILLOS  | CRUZ VERDE | 773                 |
| LAS CONDES | CRUZ VERDE | 1102,1103,1104,1105 |
