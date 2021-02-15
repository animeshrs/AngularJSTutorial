let x;
x = 123;
x = "xyz";

let y: number | string;
y = 123;
y = "xyz";

let z: number;
z = 123;
// z = 'xyz'; This will fail

interface ICar {
  color: string;
  model: string;
  topSpeed?: number;
}

// tslint:disable-next-line: one-variable-per-declaration
const car1: ICar = {
  color: 'white',
  model: 'bmw',
};

const car2: ICar = {
  color: 'red',
  model: 'audi',
  topSpeed: 150,
};

const multiply = (n1: number, n2: number): number => {
  return n1 * n2;
};
