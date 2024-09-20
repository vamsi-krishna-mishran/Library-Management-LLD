<h1>Library Management Low Level Design</h1>
<h2>Problem Statement</h2>
<a href="https://workat.tech/machine-coding/practice/design-library-management-system-jgjrv8q8b136">Problem Link</a>
<h2>Solution</h2>
<b>Directory Structure</b>
<pre>
<b>root</b>
|   .gitignore
|   library-management.csproj
|   library-management.sln
|   Program.cs
|  
+---DataLayer
|       Database.cs
|       
+---Enums
|       Limits.cs
|       Status.cs
|       
+---Models
|       Address.cs
|       Book.cs
|       BookCopy.cs
|       Borrow.cs
|       Library.cs
|       Rack.cs
|       User.cs
|       

+---Services
|       BaseService.cs
|       BookCopyService.cs
|       BookService.cs
|       BorrowService.cs
|       IdGeneratorService.cs
|       LibraryService.cs
|       PaymentService.cs
|       RackService.cs
|       SearchService.cs
|       UserService.cs
|       
|---System
|        LibraryManagement.cs
        

</pre>
<b>Appraoch</b>
<article style="text-align:justify">
low level design problems are open-ended. we should always try to solve the problem by focusing <i>SOLID , KISS and DRY</i> principles.
<br/>
<i> I followed below steps to solve the problem in a efficient way without voilating above principles.</i>
<ol>
<li>
 Clarify the requirements, figure out the entities part of the system and their properties.
</li>
<li>
Write classes for each entity with properties. only put setters and getters inside it. I place all these in a folder <i>models</i>.
</li>
<li>
To use these objects inside our system, let's create a file called database and have List of these classes. I created <i>datalayer/database.cs</i> file which is an singleton instance.
</li>
<li>
Interaction to this database should be done from services.So create services for all entities as per the requirements.
Sometimes we need to add more services based on the client requirements such as <i>generateIds, sendmails</i> etc. I created all services inside <i>services</i> folder.
</li>
<li>
Create a fascade class that encapsulates all the services and provide <b>interface/API/public methods</b> to handle client use cases.
</li>
</ol>
<small><b>Note:</b> we can interact with this fascade class from CLI or Front-end tech.</small>
<br/>
<small><b>Desclaimer:</b> There can be multiple solutions to this design. I can't assure its the best.
<br/>
</small>

<b>Start Locally</b>
<ul>
<li> Install dotnet SDK 8.
</li>
<li> clone repository and go to folder where .csproj is present in your powershell or cmd.
</li>
<li>
   run <i>dotnet build</i> or <i>dotnet build library-management.csproj</i>
</li>
<li>
  run <i>dotnet run</i> to get the code run.
</li>

</ul>
</article>
