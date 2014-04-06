Glimpse.EventStore
==================

Glimpse (http://getglimpse.com/) plugin for Event Store (http://geteventstore.com).

Plugin adds an 'Event Store' tab to Glimpse client that displays all activity on EventStore connection, including duration, arguments and results.

Usage
=====

1. Add Glimpse.EventStore package to the project where you create an instance of `IEventStoreConnection`,
2. Replace calls to `EventStore.ClientAPI.EventStoreConnection.Create(...)` with `Glimpse.EventStore.ProfiledEventStoreConnection.Create(...)`. `ProfiledEventStoreConnection` has exactly the same `Create` methods as `EventStoreConnection`. 

No other changes in the code are needed.

You can hide user password provided in `UserCredentials` by adding an entry to `<appSettings>` in web.config file:

    <add key="Glimpse.EventStore:HideUserCredentialsPassword" value="True" />

Compatibility
=============

Make sure you pick up a correct version of the plugin based on the version of EventStore you're running. NuGet package dependencies are set up accordingly.

EventStore 2.0 <- Plugin 1.0

EventStore 3.0 <- Plugin 2.0

Roadmap
=======

Features to implement:

1. ~~Optionaly hiding `UserCredentials.Password` field~~ (1.0.0-alpha4),
2. ~~Add support fo showing activities in Timeline~~ (1.0.0),
3. Proper timings for async methods (currently timings show only the duration of returning a `Task` instance, not the actual execution of the `Task`),
4. ~~Deserialization of individual events' body and metadata~~ (1.0.0-alpha4),
5. Improvements in the UI,
6. Timings for event handler executions (currently all events handler executions have a duration of 1ms).

Disclaimer
==========

This plugin may contain bugs - if you're lucky to find one, please report it on GitHub.

Also, do not withhold any suggestions or feedback - @jakubkonecki.
