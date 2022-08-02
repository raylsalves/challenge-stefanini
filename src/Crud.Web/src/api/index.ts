import axios, { Method, AxiosResponse } from "axios";
const endpoint = "http://localhost:5000/api";

const api = axios.create({
  baseURL: endpoint,
});

const request = <T>(
  method: Method,
  url: string, // eslint-disable-next-line
  params?: any // params are optional and the type vary within the request
): Promise<AxiosResponse<T>> => {
  return api.request<T>({ method, url, params });
};

export default request;
