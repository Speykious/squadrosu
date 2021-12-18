// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Testing;

namespace Squadrosu.Game.Tests.Visual;

public class SquadrosuTestScene : TestScene
{
    protected override ITestSceneTestRunner CreateRunner() => new SquadrosuTestSceneTestRunner();

    private class SquadrosuTestSceneTestRunner : SquadrosuGameBase, ITestSceneTestRunner
    {
        private TestSceneTestRunner.TestRunner runner;

        protected override void LoadAsyncComplete()
        {
            base.LoadAsyncComplete();
            Add(runner = new TestSceneTestRunner.TestRunner());
        }

        public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
    }
}
