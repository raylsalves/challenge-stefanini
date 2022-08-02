import axios from "axios";
import { InjectionKey } from "vue";
import { createStore, Store, useStore as baseUseStore } from "vuex";
import { City, Person } from "../types";

const endpoint = "http://localhost:5000/api/";

export interface State {
  persons: Person[];
  cities: City[];
  cityModal: boolean;
  personModal: boolean;
  editFlag: boolean;
  editId: string;
  personEdit: Person;
  citieEdit: City;
}

export const key: InjectionKey<Store<State>> = Symbol();

export const store = createStore<State>({
  state: {
    persons: [],
    cities: [],
    cityModal: false,
    personModal: false,
    editFlag: false,
    editId: "",
    personEdit: { id: "", name: "", age: 0, cityId: "" },
    citieEdit: { id: "", name: "", uf: "" },
  },
  mutations: {
    setPersons(state: State, persons: Person[]) {
      state.persons = persons;
    },
    setCities(state: State, cities: City[]) {
      state.cities = cities;
    },
    toggleCityModal(state: State) {
      state.cityModal = !state.cityModal;
    },
    togglePersonModal(state: State) {
      state.personModal = !state.personModal;
    },
    toggleEdit(state: State) {
      state.editFlag = !state.editFlag;
    },
    setEditId(state: State, id: string) {
      state.editId = id;
    },
    setEditPerson(state: State, person: Person) {
      state.personEdit = person;
    },
    setEditCity(state: State, city: City) {
      state.citieEdit = city;
    },
  },
  getters: {
    getPersons(state: State) {
      return state.persons;
    },
    getCities(state: State) {
      return state.cities;
    },
    getEditFlag(state: State) {
      return state.editFlag;
    },
    getCityModal(state: State) {
      return state.cityModal;
    },
    getPersonModal(state: State) {
      return state.personModal;
    },
    getEditId(state: State) {
      return state.editId;
    },
    getPersonEdit(state: State) {
      return state.personEdit;
    },
    getCitieEdit(state: State) {
      return state.citieEdit;
    },
  },
});

export function useStore() {
  return baseUseStore(key);
}
