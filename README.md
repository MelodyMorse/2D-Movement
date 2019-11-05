# 2D Movement

Mel's Edit: I was inspired to do a little work on Brackey's 2D Character controller that I think makes the script more user friendly

Major changes
Fields: m_jumpForce has been replaced with jumpHeight, which stores the number of units the character's jump height is to be.  runSpeed has been moved from PlayerMovement.cs to CharacterController2D.cs.  I thought it was akward how runSpeed was the only field related to adjusting character movement that wasn't on the character controller script so I moved it. Character will now run at runSpeed units per second. 

I added a custom editor script to the charachter controller so that there are now arrow handles on the player to adjust jumpHeight and runSpeed in the scene view if the user wishes, as well as a visual representation of the player's jump arc at runSpeed

NOTE: I still need to do some tests to verify jump arc is 100% accurate.  At worst right now it is still a close representation.  Just a heads up if you want to use it.
Project files for our tutorial on 2D Movement in Unity.

End Mel's Edit

The complete Unity project is under "2D Movement" and the newest version of the CharacterController2D can be found [here](https://github.com/Brackeys/2D-Character-Controller).

The asset pack used for the environment is Sunny Land which you can download [here](https://assetstore.unity.com/packages/2d/characters/sunny-land-103349).

Check out our [YouTube Channel](http://youtube.com/brackeys) for more tutorials.