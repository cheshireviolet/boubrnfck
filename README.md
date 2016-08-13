# boubrnfck
Another esolang based on brainfuck, my objective is to make it less repetitive and add some more versatility. In boubrnfck you have two tapes, one is the usual brainfuck tape, the second one is a function tape, in each slot you'll be able to store a whole function. See commands for more details.

# Changelog
1.1 - Fixed bug that wouldn't do loops inside loops (as in a simple cat ,[.[-],] ) 

# Commands
+-[],.<> Just as the original brainfuck.

{ everything between these will be written on the Function Position}

v will move the function pointer forward 

^ will move the function pointer backwards

@ will execute the function at the function pointer

# Example

+++++++++++[->+++++++>+++++++++>++++++++++>+++++++++>+++>++++++++++>+++++++++>+++++++++>++++++++++>+++<<<<<<<<<<]>+.>++.>++++.>+++.>-.>++++++.>+++++.>++++++.>+++++.>...

this code will print "Nerf this!!!", let's compare with a boubrnfck version:

{+++}@@@++[->@@+>@@@>@@@+>@@@>@>@@@+>@@@>@@@>@@@+>@<<<<<<<<<<]v{>+}v{^@^@vv}^@.@+.v@.^@++.>-.v@++.@+.@++.@+.>...

That's a lot of compression based on repetition!!! It has a lot of potential, give it a try!
