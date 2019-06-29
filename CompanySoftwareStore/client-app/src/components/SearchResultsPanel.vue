<template>
    <div class="search-results-panel">
        <div v-bind:key="`item-${index}`" v-for="(resultItem, index) in searchResultsList">
            <SearchResultsItem v-bind:resultItem="resultItem" />
        </div>
    </div>
</template>

<script>
    import SearchResultsItem from './SearchResultsItem';

    export default {
        name: "SearchResultsPanel",
        props: {
            searchResultsList: Array
        },
        components: {
            SearchResultsItem
        }
    }
</script>

<style scoped>
    .search-results-panel {
        width: 450px;
        margin: 20px;
        padding: 10px;
        box-sizing: border-box;
    }
</style>