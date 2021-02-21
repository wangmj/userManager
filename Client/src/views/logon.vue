<template>
  <div>
    <div class="logon-container" :style="logonContainerStyle">
      <a-row type="flex" align="bottom" :gutter="[5, 5]">
        <a-col span="8"> 用户名：</a-col>
        <a-col span="12"><a-input v-model="name"></a-input> 
        <input type="text" v-model="name" /></a-col>
      </a-row>
      <a-row type="flex" align="bottom" :gutter="[5, 10]">
        <a-col span="8"> 密码:</a-col>
        <a-col span="12"
          ><a-input-password v-model="pwd"></a-input-password>
        </a-col>
      </a-row>
      <a-row>
        <a-col>
          <a-button type="primary" @click="onSubtmit">登录</a-button>
        </a-col>
      </a-row>
    </div>
  </div>
</template>
<script>
import { onMounted, ref, computed, reactive } from "vue";
export default {
  setup() {
    let name = ref("name111");
    let pwd = ref("pwd111");

    const logonContainerLeft = ref(0);
    const logonContainerTop = ref(0);
    const logonContainerStyle = computed(
      () =>
        "left:" +
        logonContainerLeft.value +
        "px;top:" +
        logonContainerTop.value +
        "px"
    );

    const onSubtmit = () => {
      console.log(name.value, pwd.value);
    };
    onMounted(() => {
      logonContainerLeft.value = document.body.offsetWidth / 2 - 250;
      logonContainerTop.value = document.body.offsetHeight / 2 - 250;
      console.log(logonContainerLeft, logonContainerTop);
    });
    return { name, pwd, onSubtmit, logonContainerStyle };
  },
  mounted() {
    console.log("width222", this.name);
  },
};
</script>
<style lang="less"  scoped>
.logon-container {
  width: 400px;
  height: 300px;
  position: absolute;
}
</style>