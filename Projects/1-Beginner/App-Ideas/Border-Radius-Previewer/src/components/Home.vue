<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        <p>CSS: border-radius: {{ cssStr }};</p>
        <div style="float:left;">
            A: <input v-model="a" v-on:change="updateRadius" /><br />
            B: <input v-model="b" v-on:change="updateRadius" /><br />
            C: <input v-model="c" v-on:change="updateRadius" /><br />
            D: <input v-model="d" v-on:change="updateRadius" /><br />
            E: <input v-model="e" v-on:change="updateRadius" /><br />
            F: <input v-model="f" v-on:change="updateRadius" /><br />
            G: <input v-model="g" v-on:change="updateRadius" /><br />
            H: <input v-model="h" v-on:change="updateRadius" /><br />

            <div style="float:right; margin-top:10px;"><button v-on:click="copyToClipboard">copy to clipboard</button></div>
        </div>

        <div class="box" :style="cssProps">
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Home',

        props: {
            msg: String,
            cssStr: String,
            a: Number,
            b: Number,
            c: Number,
            d: Number,
            e: Number,
            f: Number,
            g: Number,
            h: Number,
        },

        computed: {
            cssProps() {
                return {
                    '--rad': this.a + "% " + this.b + "% " + this.c + "% " + this.d + "% / " + this.e + "% " + this.f + "% " + this.g + "% " + this.h + "%",
                }
            }
        },

        methods: {
            updateRadius: function () {
                this.cssStr = this.a + "% " + this.b + "% " + this.c + "% " + this.d + "% / " + this.e + "% " + this.f + "% " + this.g + "% " + this.h + "%";
            },

            copyToClipboard: function () {
                navigator.clipboard.writeText("CSS: border-radius: " + this.cssStr + ";");
                alert("Copied to clipboard: " + "CSS: border-radius: " + this.cssStr + ";");
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    div.box {
        float:right;
        background-color: blue;
        width: 200px;
        height: 200px;
        border: 4px;
        border-color: cornflowerblue;
        border-radius: var(--rad);
    }

    div.home {
        width: 500px;
    }
</style>