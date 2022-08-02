export type City = {
  id: string;
  name: string;
  uf: string;
};

export type Person = {
  id: string;
  name: string;
  age: number;
  cityId: string;
};

export type Response = {
  data: City | Person;
  sucess: boolean;
  error: string;
};
