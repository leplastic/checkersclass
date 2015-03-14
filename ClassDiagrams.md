# Initial Class Diagram #

Initially, I'm planning to implement all the hard work on the Board and Game classes. As it's being written in C#, it will use events for game operations.

![http://i34.tinypic.com/2wbu8gx.jpg](http://i34.tinypic.com/2wbu8gx.jpg)


---


# Class Diagram update (7 Aug 2010) #

Updated the class diagram to reflect some design changes. The `Checkers` class is now a factory, to simplify instance creation to final users without the need to expose some classes to clients.

Note: The classes `GameLog` and `Score` are not the same.

![http://i36.tinypic.com/311ql28.jpg](http://i36.tinypic.com/311ql28.jpg)