import React from 'react';
import styles from './MainPage.module.scss';

function MainPage() {
  return (
    <div className={styles.wrapper}>
      <header className={styles.header}>
        <div className={styles.logo}>Brimo</div>
      </header>
      <nav className={styles.nav_wpapper}>
        <span className={styles.nav_item}>Моя страница</span>
        <span className={styles.nav_item}>Новости</span>
        <span className={styles.nav_item}>Мессенджер</span>
        <span className={styles.nav_item}>Подписки</span>
        <span className={styles.nav_item}>Подписчики</span>
        <span className={styles.nav_item}>Настройки</span>
      </nav>
    </div>
  );
}
export default MainPage;
