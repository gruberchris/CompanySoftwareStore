<template>
    <div class="search-input">
        <form @submit.prevent="handleSubmit" autocomplete="off">
            <label for="search-query-input"></label>
            <input id="search-query-input" type="text" v-model="searchQuery" placeholder="ie, 2 or 2.0 or 2.0.0" autofocus />
            <input id="submit-button" type="submit" value="Search">
        </form>
    </div>
</template>

<script>
    export default {
        name: "SearchInput",
        data() {
            return {
                searchQuery: ''
            }
        },
        methods: {
            handleSubmit() {
                this.$emit('clearResults');

                if (this.searchQuery.match(/\d?\.?\d?\.?\d/)) {
                    this.$emit('searchSubmitted', this.searchQuery);
                } else {
                    this.searchQuery = '';
                }
            }
        }
    }
</script>

<style scoped>
    input {
        display: inline-block;
        font-size: 20px;
        box-sizing: border-box;
        transition: .5s;
    }
    input[type="text"] {
        background: #00B5EC;
        width: 340px;
        height: 50px;
        border: none;
        outline: none;
        padding: 0 25px;
        border-radius: 25px 0 0 25px;
    }
    input[type="submit"] {
        border-radius: 0 25px 25px 0;
        width: 150px;
        height: 50px;
        border: none;
        outline: none;
        cursor: pointer;
        background: #FF6A00;
        color: #000;
    }
    input[type="submit"]:hover {
        background: #CCFF00
    }
</style>