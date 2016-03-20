Controller for interacting with Microsoft Flight Simulator X.

# Projects #

## FSXi ##
A graphical and USB interface for interacting with FSX. Provides control of all the instruments available in the Cessna 172 as well as control over the simulator itself.

## FSXi Unit Tests ##
Unit tests for the FSXi application.

## FSXi Firmware ##
The firmware for the microcontoller which allows the simulator to be controlled through external hardware peripherals. The microcontroller communicates with the FSXi application via USB, which then interacts with the FSX application.

# Software Requirements #
The following components are required to compile and run the FSXi application:
  * Microsoft Flight Simulator X SP2
  * Microsoft Flight Simulator X SDK SP2
  * Microsoft Visual Studio 2008
  * NLog - .NET logging tool
  * NUnit - .NET unit testing tool (Only needed to run unit tests)