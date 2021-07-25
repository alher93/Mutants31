# API Mutants

## Descripción

Esta API tiene como fin evaluar si una secuencia de ADN corresponde a la de un mutante o no; la secuencia de ADN es una tabla de caracteres de tamaño NxN. El criterio para determinar si alguien es mutante o humano es que en su ADN se encuentre mas de una secuencia de cuatro letras iguales.

<table style="width: 100%; text-align: center;">
<tr>
    <th style="text-align: center;">Mutante</th>
    <th style="text-align: center;">Humano</th>
</tr>
<tr>
<td style="width: 50%;">
    <table style="width: 95%;">
        <tr>
            <td style="font-weight: bold;">A</td>
            <td>T</td>
            <td>G</td>
            <td>C</td>
            <td style="font-weight: bold;">G</td>
            <td>A</td> 
        </tr>
        <tr>
            <td>C</td>
            <td style="font-weight: bold;">A</td>
            <td>G</td>
            <td>T</td>
            <td style="font-weight: bold;">G</td>
            <td>C</td> 
        </tr>
        <tr>
            <td>T</td>
            <td>T</td>
            <td style="font-weight: bold;">A</td>
            <td>T</td>
            <td style="font-weight: bold;">G</td>
            <td>T</td> 
        </tr>
        <tr>
            <td>A</td>
            <td>G</td>
            <td>A</td>
            <td style="font-weight: bold;">A</td>
            <td style="font-weight: bold;">G</td>
            <td>G</td> 
        </tr>
        <tr>
            <td style="font-weight: bold;">C</td>
            <td style="font-weight: bold;">C</td>
            <td style="font-weight: bold;">C</td>
            <td style="font-weight: bold;">C</td>
            <td>T</td>
            <td>A</td> 
        </tr>
        <tr>
            <td>T</td>
            <td>C</td>
            <td>A</td>
            <td>C</td>
            <td>T</td>
            <td>G</td> 
        </tr>
    </table>
</td>

<td style="width: 50%;">

<table style="width: 95%;">
    <tr>
        <td style="font-weight: bold;">A</td>
        <td>T</td>
        <td>G</td>
        <td>C</td>
        <td>G</td>
        <td>A</td> 
    </tr>
    <tr>
        <td>C</td>
        <td style="font-weight: bold;">A</td>
        <td>G</td>
        <td>T</td>
        <td>G</td>
        <td>C</td> 
    </tr>
    <tr>
        <td>T</td>
        <td>T</td>
        <td style="font-weight: bold;">A</td>
        <td>T</td>
        <td>G</td>
        <td>T</td> 
    </tr>
    <tr>
        <td>A</td>
        <td>G</td>
        <td>A</td>
        <td style="font-weight: bold;">A</td>
        <td>C</td>
        <td>G</td> 
    </tr>
    <tr>
        <td>C</td>
        <td>T</td>
        <td>C</td>
        <td>C</td>
        <td>T</td>
        <td>A</td> 
    </tr>
    <tr>
        <td>T</td>
        <td>C</td>
        <td>A</td>
        <td>C</td>
        <td>T</td>
        <td>G</td> 
    </tr>
</table>

</td>
</tr> 
</table>

**Nota Importante:** La secuencia de ADN debe ser de magnitud NxN y debe contener solamente las letras (A,T,C,G).

## Entrada

La API recibirá como entrada un Json de la forma:

  ~~~
    { "dna": ["ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"] }
  ~~~

Como se ve en el json debe contener una llave **dna** cuyo valor es un arreglo de *strings* que representan la secuencia de ADN.

## Respuesta

La API responderá a las solicitudes de la siguiente manera:

* *Cuando la secuencia de ADN es de un Mutante*: se devolverá un **StatusCode 200 OK**
* *Cuando la secuencia de ADN es de un Humano*: se devolverá un **StatusCode 403 Fordibben** 

## Como consumir

La API se encuentra alojada en la siguiente URL:  https://9twlb5own8.execute-api.us-east-1.amazonaws.com

### POST

Este es el principal servicio que expone la API el cuál se encarga de evaluar si la secuencia de ADN pertenece a un mutante o a un humano; se debe consumir de la siguiente manera:

* *URL*: https://9twlb5own8.execute-api.us-east-1.amazonaws.com/api/mutant
* *Headers*: "Content-Type": "application/json"
* *Body*: { "dna": ["ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"] }

### GET

Este es un servicio auxiliar que devuelve las estadisticas de las secuencias de ADN que se han evaluado y arroja como respuesta un Json con la siguiente forma:

 ~~~
    {"count_mutant_dna":40, "count_human_dna":100: "ratio":0.4} 
 ~~~

 ***Para consumir simplemente se debe navegar a la siguiente URL*** https://9twlb5own8.execute-api.us-east-1.amazonaws.com/api/mutant/stats desde cualquier navegador.
 
 ## Implementación

 ### Herramientas

 Para la realización de la API se utilizaron las siguientes herramientas:

 * ASP.NET Core 3.1 Web API
 * Entity Framework Core
 * NUnit

### Code Coverage

Es importante aclarar que se hizo uso del decorador **[ExcludeFromCodeCoverage]** en las siguientes clases: 

* Program.cs
* Startup.cs
* Todos los archivos de la carpeta Migrations
* Mutant.cs
* LambdaEntryPoint.cs

Estas clases se excluyeron porque:

* En el caso de *Program* y *Startup* son clases generadas por .NET Core cuando se crea la Web API y a las cuales no se les hicieron modificaciones significativas.

* En el caso de las clases en la carpeta Migrations es porque estas clases son autogeneradas por Entity Framework Core y que se pueden autogenerar las veces que se quiera por lo tanto no vale la pena el esfuerzo de hacer pruebas unitarias a clases que eventualmente pueden ser borradas.

* En el caso de Mutant es el DTO que se utiliza para crear la tabla del historial de evaluaciones de secuencia de ADN y solamente contiene la estructura de esta tabla; lo unico que valdría la pena probar en esta clase son las validaciones, pero por este motivo se sacaron en una clase aparte y se probaron; dejando en la clase Mutant solamente los mensajes de error.

* En el caso de LambdaEntryPoint es porque es una clase auxiliar que se utiliza para poder ejecutar una ASP.NET core Web API como una función AWS lambda; esto tiene que ver más con el despliegue y publicación de la API que con su funcionamiento.

El resto de clases de la Web API se probaron correctamente y al ejecutar la herramienta de **Code Coverage** de Visual Studio *arroja una cobertura de código del 100%*.

Para ejecutar el code coverage debe descargar la Web API desde este repositorio, abrirla con un **Visual Studio 2019 enterprise** e ir al menú **Test -> Analyze code coverage for all tests** 

### Tráfico

La capacidad de manejar el tráfico o concurrencia depende de la infraestructura en la cual esté alojada la API en este caso la API fue alojada **en una función lambda en la capa gratuita de AWS** la cuál se configuró por defecto y tiene una capacidad de concurrencia reservada de 1000 operaciones simultáneas; es decir, que esta API va a soportar solamente 1000 peticiones al mismo tiempo, si este límite se excede se empezará a responder a las peticiones con un codigo de error 429.

Esta información se encuentra en los siguientes artículos de la documentación de AWS:

* [Managing concurrency for a Lambda function](https://docs.aws.amazon.com/lambda/latest/dg/configuration-concurrency.html)
* [AWS Lambda function scaling](https://docs.aws.amazon.com/lambda/latest/dg/invocation-scaling.html)

### Despliegue

La Wep API se desplegó en la capa gratuita de AWS utilzando los servicios:

* **Virtual Private Cloud (VPC)** para crear una red en la que la función de AWS lambda y la base de datos RDS puedan verse y permitir que la API acceda a la BD. 
* **AWS lambda** para alojar la api.
* **RDS** para crear la base de datos SQL Server.



