protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Настройка составного первичного ключа для Follow
    modelBuilder.Entity<Follow>()
        .HasKey(f => new { f.FollowerId, f.FolloweeId });

    // Настройка отношений для Follow и User
    modelBuilder.Entity<Follow>()
        .HasOne(f => f.Follower)
        .WithMany(u => u.Following) // Здесь у вас должно быть свойство в User для списка подписок
        .HasForeignKey(f => f.FollowerId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Follow>()
        .HasOne(f => f.Followee)
        .WithMany(u => u.Followers) // Здесь у вас должно быть свойство в User для списка подписчиков
        .HasForeignKey(f => f.FolloweeId)
        .OnDelete(DeleteBehavior.Restrict);

    // Настройка отношений для Chat и User1
    modelBuilder.Entity<Chat>()
        .HasOne(c => c.User1)
        .WithMany(u => u.ChatsAsUser1)
        .HasForeignKey(c => c.User1Id)
        .OnDelete(DeleteBehavior.Restrict);

    // Настройка отношений для Chat и User2
    modelBuilder.Entity<Chat>()
        .HasOne(c => c.User2)
        .WithMany(u => u.ChatsAsUser2)
        .HasForeignKey(c => c.User2Id)
        .OnDelete(DeleteBehavior.Restrict);

    // Настройка автоинкрементного значения для поля Id
    modelBuilder.Entity<Chat>()
        .Property(c => c.Id)
        .ValueGeneratedOnAdd(); // Указывает, что значение будет сгенерировано при добавлении
}