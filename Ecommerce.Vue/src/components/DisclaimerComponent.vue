<template>
    <div v-if="!isHidden">
        <div className='disclaimer-bar'>
            <div className='group'>
                <p>
                    This is a proof of concept project.
                    <br>
                    This site is for demonstration purposes only!
                    <br>
                    It is not an actual shopping web site where you can buy the displayed products.
                    All the displayed images are Copyright-free and they do not belong to me.
                </p>
            </div>
            <div class='close-button'>
                <button @click="hide()">X</button>
            </div>
        </div>
    </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';

export default defineComponent({
    data() {
        return {
            isHidden: false
        };
    },
    methods:{
      hide(){
        this.isHidden = true;
      }
    },
});
</script>
<style scoped>

.disclaimer-bar{
    background-color: #fcf488;
    text-align: center;
    display: flex;
    flex-direction: row;
    word-wrap: break-word;
    align-items: center;
    border: 1px solid black;
    margin-bottom: 4px;
}
.disclaimer-bar .group{
    width: 97%;
    display: inline-block;
}
    
.disclaimer-bar .close-button{
    width: 3%;
    margin: 8px;
    text-align: center;
}
</style>
