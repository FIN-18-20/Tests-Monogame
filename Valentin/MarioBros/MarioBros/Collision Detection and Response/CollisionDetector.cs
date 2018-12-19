﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class CollisionDetector
    {
        Game1 game;
        IAnimatedSprite starSprite;
        ISpriteFactory factory = new SpriteFactory();
        public List<Block> destroyedBlocks = new List<Block>();
        public List<ICollectable> obtainedItems = new List<ICollectable>();
        public ItemCollisionResponder itemResponder;
        public EnemyCollisionResponder enemyResponder;
        public BlockCollisionResponder blockResponder;
        public FireballCollisionResponder fireballResponder;
        public ThrowingStarCollisionResponder throwingStarResponder;
        public PipeCollisionResponder pipeResponder;
        public List<Block> standingBlocks;
        public List<Pipe> standingPipes;

        public CollisionDetector(Mario mario, Game1 game)
        {
            this.game = game;
            starSprite = factory.build(SpriteFactory.sprites.star);
            itemResponder = new ItemCollisionResponder(game);
            blockResponder = new BlockCollisionResponder(game);
            enemyResponder = new EnemyCollisionResponder(game);
            fireballResponder = new FireballCollisionResponder(mario, game);
            throwingStarResponder = new ThrowingStarCollisionResponder(mario, game);
            pipeResponder = new PipeCollisionResponder(game);
            standingBlocks = new List<Block>();
            standingPipes = new List<Pipe>();
        }

        public void Detect(Mario mario, List<Fireball> levelFireballs, List<ThrowingStar> levelThrowingStars, List<Enemy> levelEnemies,
            List<Block> levelBlocks, List<ICollectable> levelItems, List<Pipe> levelPipes, List<Spike> levelSpikes, List<Trampoline> levelTrampolines)
        {
            standingBlocks = new List<Block>();
            standingPipes = new List<Pipe>();
            Rectangle marioRect = mario.state.GetBoundingBox(new Vector2(mario.position.X, mario.position.Y));
            foreach (Enemy enemy in levelEnemies)
            {
                Rectangle enemyRect = enemy.GetBoundingBox();
                if (!enemy.isDead && mario.invicibilityFrames == 0)
                {
                    if (marioRect.Intersects(enemyRect))
                    {
                        enemyResponder.MarioEnemyCollide(mario, enemy);
                    }
                }
                foreach (Fireball fireball in levelFireballs)
                {
                    if (!enemy.isDead)
                    {
                        Rectangle fireballRect = fireball.GetBoundingBox();
                        if (fireballRect.Intersects(enemyRect))
                        {
                            fireballResponder.EnemyFireballCollide(enemy, fireball);
                        }
                    }
                }
                foreach (ThrowingStar throwingStar in levelThrowingStars)
                {
                    if (!enemy.isDead)
                    {
                        Rectangle throwingStarRect = throwingStar.GetBoundingBox();
                        if (throwingStarRect.Intersects(enemyRect))
                        {
                            throwingStarResponder.EnemyThrowingStarCollide(enemy, throwingStar);
                        }
                    }
                }
                foreach (Block block in levelBlocks)
                {
                    Rectangle blockRect = block.GetBoundingBox();
                    if (blockRect.Intersects(enemyRect) && !enemy.isMagic)
                    {
                        blockResponder.EnemyBlockCollide(enemy, block);
                    }
                }
                foreach (Enemy otherEnemy in levelEnemies)
                {
                    Rectangle otherEnemyRect = enemy.GetBoundingBox();
                    if (otherEnemy != enemy && enemyRect.Intersects(otherEnemyRect) && !enemy.isMagic)
                    {
                        enemyResponder.EnemyEnemyCollide(enemy, otherEnemy);
                    }
                }
                foreach (Pipe pipe in levelPipes)
                {
                    Rectangle pipeRect = pipe.GetBoundingBox();
                    if (pipeRect.Intersects(enemyRect))
                    {
                        pipeResponder.PipeEnemyCollide(enemy, pipe);
                    }
                }
            }

            foreach (Pipe pipe in levelPipes)
            {
                Rectangle pipeRect = pipe.GetBoundingBox();
                if (pipeRect.Intersects(marioRect))
                {
                    pipeResponder.PipeMarioCollide(mario, pipe, standingPipes);
                }
            }

            foreach (ICollectable item in levelItems)
            {
                Rectangle itemRect = item.GetBoundingBox();
                if (marioRect.Intersects(itemRect) && !item.isSpawning)
                {
                    obtainedItems.Add(item);
                    itemResponder.MarioItemCollide(item, mario);
                }
                foreach (Pipe pipe in levelPipes)
                {
                    Rectangle pipeRect = pipe.GetBoundingBox();
                    if (pipeRect.Intersects(itemRect))
                    {
                        pipeResponder.PipeItemCollide(item, pipe);
                    }
                }
            }

            foreach (Block block in levelBlocks)
            {
                Rectangle blockRect = block.GetBoundingBox();
                if (marioRect.Intersects(blockRect))
                {
                    blockResponder.MarioBlockCollide(mario, block, destroyedBlocks, standingBlocks);
                }

                foreach (Fireball fireball in levelFireballs)
                {
                    Rectangle fireballRect = fireball.GetBoundingBox();
                    if (fireballRect.Intersects(blockRect))
                    {
                        fireballResponder.BlockFireballCollide(block, fireball);
                    }
                }
                foreach (ThrowingStar throwingStar in levelThrowingStars)
                {
                    Rectangle throwingStarRect = throwingStar.GetBoundingBox();
                    if (throwingStarRect.Intersects(blockRect))
                    {
                        throwingStarResponder.BlockThrowingStarCollide(block, throwingStar);
                    }
                }
                foreach (ICollectable item in levelItems)
                {
                    Rectangle itemRect = item.GetBoundingBox();
                    if (blockRect.Intersects(itemRect) && !item.isSpawning)
                    {
                        blockResponder.ItemBlockCollide(item, block);
                    }
                }
            }

            foreach (Spike spike in levelSpikes)
            {
                Rectangle spikeRect = spike.GetBoundingBox();
                if (marioRect.Intersects(spikeRect))
                {
                    mario.TakeDamage();
                }
            }
            foreach (Trampoline trampoline in levelTrampolines)
            {
                Rectangle trampolineRect = trampoline.GetBoundingBox();
                if (marioRect.Intersects(trampolineRect))
                {
                    if (mario.physState.GetType().Equals(new VVVVVVAirState(mario, 1).GetType()))
                    {
                        mario.physState = new VVVVVVGroundState(mario, mario.gravityDirection);
                    }
                    mario.physState.Flip();
                }
            }

            foreach (ICollectable obtainedItem in obtainedItems)
            {
                levelItems.Remove(obtainedItem);
            }
            foreach (Block destroyedBlock in destroyedBlocks)
            {
                levelBlocks.Remove(destroyedBlock);
            }
        }
    }
}
