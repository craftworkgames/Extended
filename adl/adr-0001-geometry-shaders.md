<!-- https://github.com/joelparkerhenderson/architecture_decision_record/blob/master/adr_template_madr.md -->

# Geometry Shaders

* Status: Rejected
* Deciders: [@lithiumtoast](https://github.com/lithiumtoast)
* Date: 2020-08-01 <!-- YYYY-MM-DD when the decision was last updated -->

Technical Story: https://github.com/craftworkgames/Ankura/issues/1

## Context and Problem Statement

Should Ankura support geometry shaders?

## Decision Drivers <!-- optional -->

* Metal does not support geometry shaders.
* Performance of geometry shaders implementations are not consistent accross hardware vendors.
* Performance problems when geometry shaders are generating primitives that are to be stored in slower access mediums off chip.
* Another stage in the graphics pipeline which is competing for resources which could effectively be used somewhere else such as the vertex or fragment stage.
* The practical function of geometry shaders can effectively be done instead using vertex shaders with advanced techniques, compute shaders, tesselation, or instancing. 
* MonoGame does not support geometry shaders resulting in some, if not most, developers who are not unfamiliar with how geometry shaders work or even their purpose.

## Considered Options

* Do not support geometry shaders.
* Support geometry shaders but only allow their use for specific graphics APIs which support them such as OpenGL and DirectX. It would then be up to the developer to decide whether to use geometry shaders for their game or not based on their desired target platforms and target hardware.

## Decision Outcome

Chosen option: "Do not support geometry shaders", because (1) Ankura is aimed to support multiple platforms in a consistent fashion; (2) the API of Ankura should remain minimal so that developers have less cognitive load.

### Positive Consequences <!-- optional -->

* Ankura can support Metal and generally continue to support multiple graphic APIs for multiple platforms. 
* The amount of knowledge the developer needs to know to use and be effective with Ankura decreases.

### Negative Consequences <!-- optional -->

* Developers must use other means to solve problems which geometry shaders can solve.

## Links <!-- optional -->

* [Vertex Shader Tricks by Bill Bilodeau at GDC 2014](https://archive.org/details/GDC2014Bilodeau)
* [A Fistful of Frames by Klonan & posila at the Factario (video game) blog](https://factorio.com/blog/post/fff-251)
* [Why Geometry Shaders Are Slow (Unless you’re Intel) by Joshua Barczak](http://www.joshbarczak.com/blog/?p=667)