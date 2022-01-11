const API_BASE_URL_DEVELOPMENT = 'https://localhost:7296';
const API_BASE_URL_PRODUCTION = 'https://aspnetcorereacttutorial-aspnetserver.azurewebsites.net';

const ENDPOINTS = {
    GET_ALL_PLANTS: 'get-all-plants',
    GET_PLANT_BY_ID: 'get-plant-by-id',
    CREATE_PLANT: 'create-plant',
    UPDATE_PLANT: 'isWaterable',
    DELETE_PLANT_BY_ID: 'delete-plant-by-id'
};

const development = {
    API_URL_GET_ALL_PLANTS: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_PLANTS}`,
    API_URL_GET_PLANT_BY_ID: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_PLANT_BY_ID}`,
    API_URL_CREATE_PLANT: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.CREATE_PLANT}`,
    API_URL_UPDATE_PLANT: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.UPDATE_PLANT}`,
    API_URL_DELETE_PLANTT_BY_ID: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.DELETE_PLANT_BY_ID}`
};

const production = {
    API_URL_GET_ALL_PLANTS: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_PLANTS}`,
    API_URL_GET_PLANT_BY_ID: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_PLANT_BY_ID}`,
    API_URL_CREATE_PLANT: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.CREATE_PLANT}`,
    API_URL_UPDATE_PLANT: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.UPDATE_PLANT}`,
    API_URL_DELETE_PLANTT_BY_ID: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.DELETE_PLANT_BY_ID}`
};

const Constants = process.env.NODE_ENV === 'development' ? development : production;

export default Constants;
