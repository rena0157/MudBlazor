﻿#pragma warning disable CS1998 // async without await
#pragma warning disable IDE1006 // leading underscore

using FluentAssertions;
using NUnit.Framework;
using static Bunit.ComponentParameterFactory;

namespace MudBlazor.UnitTests.Components
{
    [TestFixture]
    public class ButtonsTests
    {
        private Bunit.TestContext ctx;

        [SetUp]
        public void Setup()
        {
            ctx = new Bunit.TestContext();
            ctx.AddTestServices();
        }

        [TearDown]
        public void TearDown() => ctx.Dispose();

        /// <summary>
        /// MudButton whithout specifying HtmlTag, renders a button
        /// </summary>
        [Test]
        public void MudButtonShouldRenderAButtonByDefault()
        {
            var comp = ctx.RenderComponent<MudButton>();
            //no HtmlTag nor Link properties are set, so HtmlTag is button by default
            comp.Instance
                .HtmlTag
                .Should()
                .Be("button");
            //it is a button, and has by default stopPropagation on onclick
            comp.Markup
                .Replace(" ", string.Empty)
                .Should()
                .StartWith("<button")
                .And
                .Contain("stopPropagation");
        }

        /// <summary>
        /// MudButton renders an anchor element when Link is set
        /// </summary>
        [Test]
        public void MudButtonShouldRenderAnAnchorIfLinkIsSetAndIsNotDisabled()
        {
            var link = Parameter(nameof(MudButton.Link), "https://www.google.com");
            var target = Parameter(nameof(MudButton.Target), "_blank");
            var disabled = Parameter(nameof(MudButton.Disabled), true);
            var comp = ctx.RenderComponent<MudButton>(link, target);
            //Link property is set, so it has to render an anchor element
            comp.Instance
                .HtmlTag
                .Should()
                .Be("a");
            //Target property is set, so it must have the rel attribute set to noopener
            comp.Markup
                .Should()
                .Contain("rel=\"noopener\"");
            //it is an anchor and not contains stopPropagation 
            comp.Markup
                .Replace(" ", string.Empty)
                .Should()
                .StartWith("<a")
                .And
                .NotContain("__internal_stopPropagation_onclick");

            comp = ctx.RenderComponent<MudButton>(link, target, disabled);
            comp.Instance.HtmlTag.Should().Be("button");

        }

        /// <summary>
        /// MudButton whithout specifying HtmlTag, renders a button
        /// </summary>
        [Test]
        public void MudIconButtonShouldRenderAButtonByDefault()
        {
            var comp = ctx.RenderComponent<MudIconButton>();
            //no HtmlTag nor Link properties are set, so HtmlTag is button by default
            comp.Instance
                .HtmlTag
                .Should()
                .Be("button");
            //it is a button
            comp.Markup
                .Replace(" ", string.Empty)
                .Should()
                .StartWith("<button");
        }

        /// <summary>
        /// MudButton renders an anchor element when Link is set
        /// </summary>
        [Test]
        public void MudIconButtonShouldRenderAnAnchorIfLinkIsSet()
        {
            using var ctx = new Bunit.TestContext();
            var link = Parameter(nameof(MudIconButton.Link), "https://www.google.com");
            var target = Parameter(nameof(MudIconButton.Target), "_blank");
            var comp = ctx.RenderComponent<MudIconButton>(link, target);
            //Link property is set, so it has to render an anchor element
            comp.Instance
                .HtmlTag
                .Should()
                .Be("a");
            //Target property is set, so it must have the rel attribute set to noopener
            comp.Markup
                .Should()
                .Contain("rel=\"noopener\"");
            //it is an anchor
            comp.Markup
                .Replace(" ", string.Empty)
                .Should()
                .StartWith("<a");
        }

        /// <summary>
        /// MudButton whithout specifying HtmlTag, renders a button
        /// </summary>
        [Test]
        public void MudFabShouldRenderAButtonByDefault()
        {
            var comp = ctx.RenderComponent<MudFab>();
            //no HtmlTag nor Link properties are set, so HtmlTag is button by default
            comp.Instance
                .HtmlTag
                .Should()
                .Be("button");
            //it is a button
            comp.Markup
                .Replace(" ", string.Empty)
                .Should()
                .StartWith("<button");
        }

        /// <summary>
        /// MudButton renders an anchor element when Link is set
        /// </summary>
        [Test]
        public void MudFabShouldRenderAnAnchorIfLinkIsSet()
        {
            var link = Parameter(nameof(MudFab.Link), "https://www.google.com");
            var target = Parameter(nameof(MudFab.Target), "_blank");
            var comp = ctx.RenderComponent<MudFab>(link, target);
            //Link property is set, so it has to render an anchor element
            comp.Instance
                .HtmlTag
                .Should()
                .Be("a");
            //Target property is set, so it must have the rel attribute set to noopener
            comp.Markup
                .Should()
                .Contain("rel=\"noopener\"");
            //it is an anchor
            comp.Markup
                .Replace(" ", string.Empty)
                .Should()
                .StartWith("<a");
        }

        /// <summary>
        /// MudFab should only render an icon if one is specified.
        /// </summary>
        [Test]
        public void MudFabShouldNotRenderIconIfNoneSpecified()
        {
            var comp = ctx.RenderComponent<MudFab>();
            comp.Markup
                .Should()
                .NotContainAny("mud-icon-root");
        }
    }
}



