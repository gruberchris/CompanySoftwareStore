<template>
    <div class="search-results-item">
        <span class="item-name">{{resultItem.name}}</span>
        <span class="item-version">{{resultItem.version}}</span>
    </div>
</template>

<script>
    export default {
        name: "SearchResultsItem",
        props: {
            resultItem: Object
        }
    }
</script>

<style scoped>
    .search-results-item {
        display: flex;
        justify-content: center;
        padding: 10px 20px;
        color: #000;
        margin: 5px 0;
        transition: .5s;
        border: 1px solid #00B5EC;
        background: #F493F2;
        font-size: 20px;
    }
    .search-results-item span {
        margin-right: 10px;
    }
</style>