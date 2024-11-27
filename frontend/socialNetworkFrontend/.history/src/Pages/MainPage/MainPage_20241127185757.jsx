import React from 'react';
import styles from './MainPage.module.scss';

function MainPage() {
  return (
    <div className={styles.wrapper}>
      <header>Brimo</header>
      <nav className={styles.nav_wpapper}>
        <span className={styles.nav_item}>Моя страница</span>
        <span>Новости</span>
        <span>Мессенджер</span>
        <span>Подписки</span>
        <span>Подписчики</span>
        <span>Настройки</span>
      </nav>
    </div>
  );
}
export default MainPage;
