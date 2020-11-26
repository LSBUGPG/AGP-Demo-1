# Flight dynamics

A plane flies by generating a lift force to oppose gravity.

The equation for lift generated is:

> lift = &frac12; &times; v&sup2; &times; &rho; &times; S &times; C<sub>L</sub>

where:
> * v = relative velocity of the air in m/s
> * &rho; = air density in kg/m&sup3;
> * S = surface area of the aerofoil in m&sup2;
> * C<sub>L</sub> = the co-efficient of lift

## The co-efficient of lift

This is a multiplier which changes depending on the relative velocity of the air and the angle of the velocity vector relative to the aerofoil surface. This angle is known as the angle of attack. Unfortunately, there is no formula to get the co-efficient of lift given the angle of attack and the relative velocity, so this must be measured in a wind turn for each aerofoil surface.

## Back calculation

Because the equation above is relative to the surface area of the aerofoils we can calculate the lift we would need to lift our plane. For example, if our plane has a weight of 350 kg, we would need to generate a total lifting force of

> 350 &times; 9.81  = ~3,430 N

Given a wing surface area of 10.5 m&sup2; and an elevator surface area of 2 m&sup2; we'll need a lift of:

> * 12.5 L = 3430
> * L = ~275 N per m&sup2;

So to maintain altitude with a relative air speed of 25 m/s and a standard air density of 1.225 kg/m&sup3; the C<sub>L</sub> must be:

> * C<sub>L</sub> &times; 25&sup2; &times; 1.225 = 275

> * C<sub>L</sub> = ~275 &div; ~766

> * C<sub>L</sub> = ~0.36

## Calculations for a Kiwi pilot

The average weight of a kiwi is 2.4 kg. I'm going to assume the glider will weigh approximately the same. So our total for the craft is 4.8 kg.

From the above, our lift requirement is therefore:

> 4.8 &times; 9.81 = ~47.088 N

If we are getting a lift of ~275N per m&sup2; then we'll need a total lift surface area of ~0.17 m&sup2;

Sticking with a ratio of 5:1 for wings to elevator, that means our wings will need to be ~0.14 m&sup2; or ~0.07 m&sup2; each and the elevator will need to be ~0.028 m&sup2;

And if we keep the same span to depth ratio of 10:1 we'll need a wing span 10d &times; d = ~0.14 &there4; d = 0.12 (1.2m wide and 0.12m deep.)

For the elevator 2d &times; 1d = ~0.028 &there4; d = 0.12 (0.24m wide and 0.12m deep.)
