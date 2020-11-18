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