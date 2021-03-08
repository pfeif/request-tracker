# Request Tracker

## The purpose of the repo

I was required to complete a final programming project as a part of completing the Computer Programming & Analysis A.S. program at St. Petersburg College. The goal was to create a mock support ticket request tracker for an IT department. The system needed to be able to track things like the dates a ticket was opened and closed, ticket descriptions, technicians assigned, and notes related to the tickets.

I wasn't restricted to any particular technologies or tools. I could write the program in any language I liked and include any libraries or frameworks as I saw fit. I could have written this in C++, Java, Python, etc. I could have stored the data using Access, a JSON file, or even using the Pickle module if I wanted to.

## The reason it is what it is

The professor I completed this project for was also my ASP.NET professor. For that class, he made a VM available in the form of a 20 GB download, allowing the students to start with a fresh development environment with all of the tools required to take the course. I mentioned that ASP.NET Core was platform-agnostic and that switching to it could prevent the need for the VM and allow the students to code regardless of whether they were using Windows, Mac, or Linux.

The result is that this project was copmleted using only open source, cross-platform tools to make a point. I created it using C#, ASP.NET Core, Entity Framework Core, Razor Pages, and SQLite.

## How to run the code
Assuming you have .NET Core installed:
 * Clone (or download and unzip) this repository.
 * Run the following at the root directory from the command line:
   * `dotnet restore`
   * `dotnet build`
   * `dotnet run`
 * Direct your web browser to [https://localhost:5001](https://localhost:5001)
