<template>
  <div id="app">
    <div class="box">
      <h2>Search for your software by it's version number</h2>
      <SearchInput @searchSubmitted="onSearchSubmit" @clearResults="onClearResults" />
      <SearchResultsPanel v-bind:searchResultsList="searchResultsList" />
    </div>
  </div>
</template>

<script>
  import axios from 'axios';
  import cmp from 'semver-compare';
  import SearchInput from './components/SearchInput';
  import SearchResultsPanel from './components/SearchResultsPanel';

  export default {
    name: "App",
    components: {
      SearchInput,
      SearchResultsPanel
    },
    data() {
      return {
        searchQuery: '',
        searchResultsList: [],
        errors: []
      }
    },
    methods: {
      onSearchSubmit(query) {
        this.searchQuery = query;

        const companyStoreSoftwareApiUrl = process.env.VUE_APP_COMPANY_STORE_SOFTWARE_API_URL;

        axios.get(companyStoreSoftwareApiUrl)
          .then(response => this.onSearchResponse(response.data))
          .catch(error => this.errors.push(error));
      },
      onSearchResponse(data) {
        const filteredResults = data.filter(v => cmp(this.searchQuery, v.version) === -1);
        
        this.searchResultsList = filteredResults.sort((a, b) => {
          const nameA = a.name.toUpperCase();
          const nameB = b.name.toUpperCase();

          if (nameA < nameB) { return -1; }

          if (nameA > nameB) { return 1; }

          return 0;
        })
      },
      onClearResults() {
        this.searchResultsList = [];
      }
    }
  }
</script>

<style scoped>
  #app {
    display: flex;
    align-items: center;
    justify-content: center;
    margin-top: 100px;
    padding: 0;
    font-family: sans-serif;
  }
  .box {
    width: 600px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
  }
  .box h2 {
    margin: 0 0 20px;
    padding: 0;
    color: #00B5EC;
    font-size: 24px;
  }
</style>
