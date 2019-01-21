package platform.game.level;

import platform.game.Actor;
import platform.util.Input;
import platform.util.Output;
import platform.util.Sprite;

/**
 * Base class for level factories, which provides fade in transition. Subclasses
 * are requires to override <code>register</code>.
 */
public abstract class Level extends Actor {
    
    @Override
    public int getPriority() {
        return Integer.MAX_VALUE;
    }
    
    /** @return a new instance of default level */
    public static Level createDefaultLevel() {
        return new Menu();
    }
}
